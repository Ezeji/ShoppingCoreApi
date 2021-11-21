using AutoMapper;
using Microsoft.Extensions.Options;
using ShoppingCoreApi.Constants;
using ShoppingCoreApi.Models;
using ShoppingCoreApi.Models.DTO;
using ShoppingCoreApi.Services.ShoppingCart.Interfaces;
using ShoppingCoreData.Models;
using ShoppingCoreRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCoreApi.Services.ShoppingCart
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepo;
        private readonly IDiscountStoreRepository _discountStoreRepo;
        private readonly DiscountConfig _discountConfig;
        private readonly IMapper _mapper;

        public CartService(ICartRepository cartRepo, IDiscountStoreRepository discountStoreRepo, IOptionsMonitor<DiscountConfig> discountConfig,
            IMapper mapper)
        {
            _cartRepo = cartRepo;
            _discountStoreRepo = discountStoreRepo;
            _discountConfig = discountConfig.CurrentValue;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<string>> CreateCartItems(List<string> itemNames)
        {
            string result =  string.Empty;

            if (itemNames == null)
            {
                return new ServiceResponse<string>(result, InternalCode.EntityIsNull, ServiceErrorMessages.ParameterEmptyOrNull);
            }

            CartDTO cartDTO = new CartDTO
            {
                ShoppingCode = ShoppingCodeGenerator()
            };

            foreach (string itemName in itemNames)
            {
                cartDTO.ItemName = itemName.ToUpper();

                Cart cart = _mapper.Map<Cart>(cartDTO);

                await _cartRepo.AddItems(cart);

            }

            result = $"Customer's shopping code: {cartDTO.ShoppingCode}";

            return new ServiceResponse<string>(result, InternalCode.Success);

        }

        public async Task<ServiceResponse<string>> DeleteCartItems(string shoppingCode)
        {
            string result = string.Empty;

            if (string.IsNullOrEmpty(shoppingCode))
            {
                return new ServiceResponse<string>(result, InternalCode.EntityIsNull, ServiceErrorMessages.ParameterEmptyOrNull);
            }

            List<Cart> cartItems = await _cartRepo.GetItems(shoppingCode);

            if (cartItems == null)
            {
                return new ServiceResponse<string>(result, InternalCode.EntityNotFound, ServiceErrorMessages.ParameterEmptyOrNull);
            }

            foreach (Cart cartItem in cartItems)
            {
                await _cartRepo.RemoveItems(cartItem);
            }

            result = "Cart item(s) deleted";

            return new ServiceResponse<string>(result, InternalCode.Success);

        }

        public async Task<ServiceResponse<string>> GetItemsTotalAmount(string shoppingCode)
        {
            decimal result = 0;

            string amount = string.Empty;

            int numberOfVase = 0;
            int numberOfBigMug = 0;
            int numberOfNapkinsPack = 0;

            string priceOfVase = string.Empty;
            string priceOfBigMug = string.Empty;
            string priceOfNapkinsPack = string.Empty;

            if (string.IsNullOrEmpty(shoppingCode))
            {
                return new ServiceResponse<string>(amount, InternalCode.EntityIsNull, ServiceErrorMessages.ParameterEmptyOrNull);
            }

            List<Cart> cartItems = await _cartRepo.GetItems(shoppingCode);

            if (cartItems == null)
            {
                return new ServiceResponse<string>(amount, InternalCode.EntityNotFound, ServiceErrorMessages.ParameterEmptyOrNull);
            }

            foreach (Cart cartItem in cartItems)
            {
                //TODO: Use a caching system for performance gain instead of hitting the db all through the loop process

                if (cartItem.ItemsSelected.ToLower() == ProductNameConstants.Vase.ToLower())
                {
                    numberOfVase += 1;
                    DiscountStore discountStore = await _discountStoreRepo.GetItemDetailsFromStore(cartItem.ItemsSelected);
                    priceOfVase = discountStore.Price;
                }
                else if (cartItem.ItemsSelected.ToLower() == ProductNameConstants.BigMug.ToLower())
                {
                    numberOfBigMug += 1;
                    DiscountStore discountStore = await _discountStoreRepo.GetItemDetailsFromStore(cartItem.ItemsSelected);
                    priceOfBigMug = discountStore.Price;
                }
                else
                {
                    numberOfNapkinsPack += 1;
                    DiscountStore discountStore = await _discountStoreRepo.GetItemDetailsFromStore(cartItem.ItemsSelected);
                    priceOfNapkinsPack = discountStore.Price;
                }
            }

            //add amount for vase
            if (numberOfVase == 0)
            {
                //leaves conditional statement
            }
            else if (numberOfVase == 1)
            {
                result = decimal.Parse(priceOfVase.Remove(3));
            }
            else
            {
                result = numberOfVase * decimal.Parse(priceOfVase.Remove(3));
            }

            //add amount for big mug
            if (numberOfBigMug == 0)
            {
                //leaves conditional statement
            }
            else if (numberOfBigMug == 1)
            {
                result += decimal.Parse(priceOfBigMug.Remove(1));
            }
            else
            {
                decimal discount = _discountConfig.BigMug;
                decimal discountedAmount = (numberOfBigMug * decimal.Parse(priceOfVase.Remove(1))) - discount;
                result += discountedAmount;
            }

            //add amount for napkins pack
            if (numberOfNapkinsPack == 0)
            {
                //leaves conditional statement
            }
            else if (numberOfNapkinsPack == 1)
            {
                result += decimal.Parse(priceOfNapkinsPack.Remove(4));
            }
            else
            {
                decimal discount = _discountConfig.NapkinsPack;
                decimal discountedAmount = (numberOfNapkinsPack * decimal.Parse(priceOfNapkinsPack.Remove(4))) - discount;
                result += discountedAmount;
            }

            amount = result.ToString() + " " + CurrencyConstants.Euro;

            return new ServiceResponse<string>(amount, InternalCode.Success);
        }


        private string ShoppingCodeGenerator()
        {
            string shoppingCode = Guid.NewGuid().ToString().Replace("-", "").ToUpper();
            shoppingCode = shoppingCode.Substring(0, 4) + shoppingCode.Substring(7, 6);
            return shoppingCode;
        }

    }
}

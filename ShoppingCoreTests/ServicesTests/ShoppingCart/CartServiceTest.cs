using AutoMapper;
using Microsoft.Extensions.Options;
using Moq;
using ShoppingCoreApi.Models;
using ShoppingCoreApi.Services;
using ShoppingCoreApi.Services.ShoppingCart;
using ShoppingCoreApi.Services.ShoppingCart.Interfaces;
using ShoppingCoreData.Models;
using ShoppingCoreRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShoppingCoreTests.ServicesTests.ShoppingCart
{
    public class CartServiceTest
    {
        private readonly Mock<ICartRepository> cartRepoMock = new Mock<ICartRepository>();
        private readonly Mock<IDiscountStoreRepository> storeRepoMock = new Mock<IDiscountStoreRepository>();

        private readonly Mock<IOptionsMonitor<DiscountConfig>> discountConfigMock = new Mock<IOptionsMonitor<DiscountConfig>>();

        private readonly IMapper mapper;

        private ICartService cartService;

        public CartServiceTest()
        {
            DiscountConfig discountConfig = new();
            discountConfigMock.Setup(x => x.CurrentValue).Returns(discountConfig);

            MapperConfiguration configuration = new MapperConfiguration(x => x.AddProfile(new ShoppingCartProfile()));

            mapper = new Mapper(configuration);
        }

        [Fact]
        public async Task CreateCartItems_Should_Return_EntityIsNull_If_Parameter_IsNull()
        {
            //Arrange
            List<string> itemNames = null;

            cartService = new CartService(cartRepoMock.Object, storeRepoMock.Object,
                discountConfigMock.Object, mapper);

            InternalCode expected = InternalCode.EntityIsNull;

            //Act
            ServiceResponse<string> actual = await cartService.CreateCartItems(itemNames);

            //Assert
            Assert.Equal(expected, actual.ServiceCode);
        }

        [Fact]
        public async Task CreateCartItems_Should_Return_Success_If_Parameter_IsNotNull()
        {
            //Arrange
            List<string> itemNames = new List<string>()
            {
                "Big Mug",
                "Vase",
                "Big Mug"
            };

            Cart cart = new Cart
            {
                ItemsSelected = "Big Mug",
                ShoppingCode = "D0694CFA64"
            };

            cartRepoMock.Setup(x => x.AddItems(cart)).ReturnsAsync("Item(s) created");

            cartService = new CartService(cartRepoMock.Object, storeRepoMock.Object,
                discountConfigMock.Object, mapper);

            InternalCode expected = InternalCode.Success;

            //Act
            ServiceResponse<string> actual = await cartService.CreateCartItems(itemNames);

            //Assert
            Assert.Equal(expected, actual.ServiceCode);
        }

        [Fact]
        public async Task DeleteCartItems_Should_Return_EntityIsNull_If_Parameter_IsNull()
        {
            //Arrange
            string shoppingCode = string.Empty;

            cartService = new CartService(cartRepoMock.Object, storeRepoMock.Object,
                discountConfigMock.Object, mapper);

            InternalCode expected = InternalCode.EntityIsNull;

            //Act
            ServiceResponse<string> actual = await cartService.DeleteCartItems(shoppingCode);

            //Assert
            Assert.Equal(expected, actual.ServiceCode);
        }

        [Fact]
        public async Task DeleteCartItems_Should_Return_EntityNotFound_If_CartItems_IsNotFound()
        {
            //Arrange
            string shoppingCode = "D0694CFA64";

            List<Cart> cartItems = null; 

            cartRepoMock.Setup(x => x.GetItems(shoppingCode)).ReturnsAsync(cartItems);

            cartService = new CartService(cartRepoMock.Object, storeRepoMock.Object,
                discountConfigMock.Object, mapper);

            InternalCode expected = InternalCode.EntityNotFound;

            //Act
            ServiceResponse<string> actual = await cartService.DeleteCartItems(shoppingCode);

            //Assert
            Assert.Equal(expected, actual.ServiceCode);
        }

        [Fact]
        public async Task DeleteCartItems_Should_Return_Success_If_ShoppingCode_IsValid_And_CartItems_IsFound()
        {
            //Arrange
            string shoppingCode = "D0694CFA64";

            List<Cart> cartItems = new List<Cart>
            {
                new Cart
                {
                    CartId = 1,
                    ItemsSelected = "Big Mug",
                    ShoppingCode = "D0694CFA64"
                },
                new Cart
                {
                    CartId = 2,
                    ItemsSelected = "Vase",
                    ShoppingCode = "D0694CFA64"
                },
                new Cart
                {
                    CartId = 3,
                    ItemsSelected = "Big Mug",
                    ShoppingCode = "D0694CFA64"
                }
            };

            cartRepoMock.Setup(x => x.GetItems(shoppingCode)).ReturnsAsync(cartItems);

            cartService = new CartService(cartRepoMock.Object, storeRepoMock.Object,
                discountConfigMock.Object, mapper);

            InternalCode expected = InternalCode.Success;

            //Act
            ServiceResponse<string> actual = await cartService.DeleteCartItems(shoppingCode);

            //Assert
            Assert.Equal(expected, actual.ServiceCode);
        }

        [Fact]
        public async Task GetItemsTotalAmount_Should_Return_EntityIsNull_If_Parameter_IsNull()
        {
            //Arrange
            string shoppingCode = string.Empty;

            cartService = new CartService(cartRepoMock.Object, storeRepoMock.Object,
                discountConfigMock.Object, mapper);

            InternalCode expected = InternalCode.EntityIsNull;

            //Act
            ServiceResponse<string> actual = await cartService.GetItemsTotalAmount(shoppingCode);

            //Assert
            Assert.Equal(expected, actual.ServiceCode);
        }

        [Fact]
        public async Task GetItemsTotalAmount_Should_Return_EntityNotFound_If_CartItems_IsNotFound()
        {
            //Arrange
            string shoppingCode = "D0694CFA64";

            List<Cart> cartItems = null;

            cartRepoMock.Setup(x => x.GetItems(shoppingCode)).ReturnsAsync(cartItems);

            cartService = new CartService(cartRepoMock.Object, storeRepoMock.Object,
                discountConfigMock.Object, mapper);

            InternalCode expected = InternalCode.EntityNotFound;

            //Act
            ServiceResponse<string> actual = await cartService.GetItemsTotalAmount(shoppingCode);

            //Assert
            Assert.Equal(expected, actual.ServiceCode);
        }

        [Fact]
        public async Task GetItemsTotalAmount_Should_Return_Success_If_ShoppingCode_IsValid_And_CartItems_IsFound()
        {
            //Arrange
            string shoppingCode = "D0694CFA64";

            List<Cart> cartItems = new List<Cart>
            {
                new Cart
                {
                    CartId = 1,
                    ItemsSelected = "Big Mug",
                    ShoppingCode = "D0694CFA64"
                }
            };

            Cart cart = new Cart
            {
                CartId = 1,
                ItemsSelected = "Big Mug",
                ShoppingCode = "D0694CFA64"
            };

            DiscountStore discountStore = new DiscountStore
            {
                Discount = "2 for 1.5 Euros",
                DiscountStoreId = 2,
                Price = "1 Euro",
                Sku = "Big Mug"
            };

            cartRepoMock.Setup(x => x.GetItems(shoppingCode)).ReturnsAsync(cartItems);
            storeRepoMock.Setup(x => x.GetItemDetailsFromStore(cart.ItemsSelected)).ReturnsAsync(discountStore);

            cartService = new CartService(cartRepoMock.Object, storeRepoMock.Object,
                discountConfigMock.Object, mapper);

            InternalCode expected = InternalCode.Success;

            //Act
            ServiceResponse<string> actual = await cartService.GetItemsTotalAmount(shoppingCode);

            //Assert
            Assert.Equal(expected, actual.ServiceCode);
        }

    }
}

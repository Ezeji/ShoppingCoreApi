using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCoreApi.Constants
{
    internal static class CurrencyConstants
    {
        public const string Euro = "Euro(s)";
    }

    internal static class ProductNameConstants
    {
        public const string Vase = "Vase";
        public const string BigMug = "Big Mug";
        public const string NapkinsPack = "Napkins Pack";
    }

    internal static class ServiceErrorMessages
    {
        public const string Success = "The operation was successful";
        public const string Failed = "An unhandled errror has occured while processing your request";
        public const string UpdateError = "There was an error carrying out operation";
        public const string MisMatch = "The entity Id does not match the supplied Id";
        public const string EntityIsNull = "Supplied entity is null or supplied list of entities is empty. Check our docs";
        public const string EntityNotFound = "The requested resource was not found. Verify that the supplied Id is correct";
        public const string Incompleted = "Some actions may not have been successfully processed";
        public const string EntityExist = "An entity of the same name or id exists";
        public const string InvalidParam = "A supplied parameter or model is invalid. Check the docs";
        public const string UnprocessableEntity = "The action cannot be processed";
        public const string InternalServerError = "An internal server error and request could not processed";
        public const string OperationFailed = "Operation failed";

        public const string ParameterEmptyOrNull = "The parameter list is null or empty";
        public const string RequestIdRequired = "Request Id is required";
    }
}

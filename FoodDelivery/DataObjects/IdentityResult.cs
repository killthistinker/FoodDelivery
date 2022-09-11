using System.Collections.Generic;
using StatusCodes = FoodDelivery.Enums.StatusCodes;

namespace FoodDelivery.DataObjects
{
    public class IdentityResult
    {
        public List<string> ErrorMessages { get; set; }
        public StatusCodes StatusCodes { get; set; }
    }
}
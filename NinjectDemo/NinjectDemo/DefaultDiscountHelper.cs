using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NinjectDemo
{

    public interface IDiscountHelper
    {
        decimal ApplyDiscount(decimal totalParam);
    }

    public class DefaultDiscountHelper : IDiscountHelper
    {
        public decimal DiscountRate;

        public DefaultDiscountHelper(decimal discountParam)
        {
            DiscountRate = discountParam;
        }

        public decimal ApplyDiscount(decimal totalParam)
        {
            return (totalParam - (DiscountRate / 100m * totalParam));
        }
    }

    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NinjectDemo
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { set; get; }

    }

    public interface IValueCalculator
    {
        decimal ValueProduct(params Product[] products);
    }

    public class LinqValueCalculator : IValueCalculator
    {
        private IDiscountHelper discounter;

        public LinqValueCalculator(IDiscountHelper discountHelper)
        {
            discounter = discountHelper;
        }

        public decimal ValueProduct(params Product[] products)
        {
            return discounter.ApplyDiscount(products.Sum(p => p.Price));
        }
    }

    public class IterativeValueCalculator : IValueCalculator
    {
        public decimal ValueProduct(params Product[] products)
        {
            decimal totalvalue = 0;
            foreach (Product p in products)
            {
                totalvalue += p.Price;
            }

            return totalvalue;
        }
    }
}

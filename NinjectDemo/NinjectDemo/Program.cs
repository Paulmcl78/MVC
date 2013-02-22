using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;

namespace NinjectDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
            ninjectKernel.Bind<IValueCalculator>().To<IterativeValueCalculator>().WhenInjectedInto<LimitShoppingCart>();
            ninjectKernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithConstructorArgument("discountParam",50M);
            ninjectKernel.Bind<ShoppingCart>().To<LimitShoppingCart>().WithPropertyValue("ItemLimit", 200M);

            //get the interface implementation
            //IValueCalculator calcImp = ninjectKernel.Get<IValueCalculator>();

            //create the instance of shoppingcart and inject the dependency
            //ShoppingCart cart = new ShoppingCart(calcImp);
            ShoppingCart cart = ninjectKernel.Get<ShoppingCart>();

            //ShoppingCart cart2 = new LimitShoppingCart(calcImp);

            //preform the claculation and write out the result
            Console.WriteLine("Total: {0:c}", cart.CalculateStockValue());
            //Console.WriteLine("Total: {0:c}", cart2.CalculateStockValue());

            Console.ReadKey(true);
        }
    }
}

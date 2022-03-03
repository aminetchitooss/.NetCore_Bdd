using System;
using System.Collections.Generic;
using System.Linq;

namespace dotNet_BDD.Service
{
    public class PricingService : IPricingService
    {

        public decimal GetBasketValue(Basket basket)
        {
            if (!basket.Products.Any())
            {
                return 0;
            }

            decimal priceSum = basket.Products.Sum(u => u.Price);

            if (basket.User.hasNeverOrdered)
            {
                return (priceSum * 90) / 100;
            }

            return priceSum;
        }
    }

    public class Basket
    {
        public User User { get; set; }
        public List<Product> Products { get; } = new List<Product>() { };
    }

    public class User
    {
        public bool hasNeverOrdered { get; set; }

    }

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

}
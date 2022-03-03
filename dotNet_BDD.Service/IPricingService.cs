using System;
using System.Collections.Generic;

namespace dotNet_BDD.Service
{
    public interface IPricingService
    {

        decimal GetBasketValue(Basket basket);
    }


}

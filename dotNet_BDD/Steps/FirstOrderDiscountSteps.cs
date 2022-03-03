using System;
using System.Collections.Generic;
using dotNet_BDD.Service;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace dotNet_BDD.tests.Steps

{

    [Binding]
    public class FirstOrderDiscountSteps
    {
        private User _user = new User();
        private Basket _basket;
        private readonly PricingService pricingService = new PricingService();



        [Given(@"I am a first time user")]
        public void GivenIAmAFirstTimeUser()
        {

            _user = new User
            {
                hasNeverOrdered = true
            };

        }

        [Given(@"I am not a first time user")]
        public void GivenIAmNotAFirstTimeUser()
        {

            _user = new User
            {
                hasNeverOrdered = false
            };

        }


        [Given(@"an empty basket")]
        public void GivenAnEmptyBaske()
        {
            _basket = new Basket
            {
                User = _user
            };
        }


        [When(@"a (.*) € (.*) is added to basket")]
        public void WhenAnItemIsAddedToBasket(decimal price, string itemName)
        {
            _basket.Products.Add(new Product
            {
                Name = itemName,
                Price = price
            });
        }


        [Then(@"the basket value is (.*) €")]
        public void ThenTheResultShouldBe(decimal basketValue)
        {
            decimal calculatedPrice = pricingService.GetBasketValue(_basket);

            calculatedPrice.Should().Be(basketValue);
        }
    }
}

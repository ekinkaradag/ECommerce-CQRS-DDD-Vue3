using System;
using System.Collections.Generic;
using NUnit.Framework;
using ECommerce.Domain.Customers.Orders;
using ECommerce.Domain.Customers.Orders.Events;
using ECommerce.Domain.Customers.Rules;
using ECommerce.Domain.Products;
using ECommerce.Domain.SharedKernel;
using ECommerce.UnitTests.SeedWork;

namespace ECommerce.UnitTests.Customers
{
    [TestFixture]
    public class PlaceOrderTests : TestBase
    {
        [Test]
        public void PlaceOrder_WhenAtLeastOneProductIsAdded_IsSuccessful()
        {
            // Arrange
            var customer = CustomerFactory.Create();

			var orderProductsData = new List<OrderProductData>
			{
				new OrderProductData(SampleProducts.Product1Id, 2)
			};

			var allProductPrices = new List<ProductPriceData>
            {
                SampleProductPrices.Product1Price, SampleProductPrices.Product2Price
            };
            
            // Act
            customer.PlaceOrder(
                orderProductsData, 
                allProductPrices);

            // Assert
            var orderPlaced = AssertPublishedDomainEvent<OrderPlacedEvent>(customer);
            Assert.That(orderPlaced.Price, Is.EqualTo(SampleProductPrices.Product1Price.Price * 2));
        }

        [Test]
        public void PlaceOrder_WhenNoProductIsAdded_BreaksOrderMustHaveAtLeastOneProductRule()
        {
            // Arrange
            var customer = CustomerFactory.Create();

            var orderProductsData = new List<OrderProductData>();

            var allProductPrices = new List<ProductPriceData>
            {
                SampleProductPrices.Product1Price, SampleProductPrices.Product2Price
            };

            // Assert
            AssertBrokenRule<OrderMustHaveAtLeastOneProductRule>(() =>
            {
                // Act
                customer.PlaceOrder(
                    orderProductsData,
                    allProductPrices);
            });
        }

        [Test]
        public void PlaceOrder_GivenTwoOrdersInThatDayAlreadyMade_BreaksCustomerCannotOrderMoreThan2OrdersOnTheSameDayRule()
        {
            // Arrange
            var customer = CustomerFactory.Create();

			var orderProductsData = new List<OrderProductData>
			{
				new OrderProductData(SampleProducts.Product1Id, 2)
			};

            var p1 = SampleProducts.Product1Id;
            var p2 = SampleProducts.Product2Id;

			var allProductPrices = new List<ProductPriceData>
            {
                SampleProductPrices.Product1Price, SampleProductPrices.Product2Price
            };

            SystemClock.Set(new DateTime(2023, 4, 14, 11, 0, 0));
            customer.PlaceOrder(
                orderProductsData,
                allProductPrices);

            SystemClock.Set(new DateTime(2023, 4, 14, 11, 30, 0));
            customer.PlaceOrder(
                orderProductsData,
                allProductPrices);

            SystemClock.Set(new DateTime(2023, 4, 14, 12, 00, 0));

            // Assert
            AssertBrokenRule<CustomerCannotOrderMoreThan2OrdersOnTheSameDayRule>(() =>
            {
                // Act
                customer.PlaceOrder(
                    orderProductsData,
                    allProductPrices);
            });
        }
    }



    public class SampleProducts
    {
        public static readonly ProductId Product1Id = new ProductId(Guid.NewGuid());

        public static readonly ProductId Product2Id = new ProductId(Guid.NewGuid());
    }

    public class SampleProductPrices
    {
        public static readonly ProductPriceData Product1Price = new ProductPriceData(
            SampleProducts.Product1Id,
            30);

        public static readonly ProductPriceData Product2Price = new ProductPriceData(
            SampleProducts.Product2Id,
            (decimal)79.99);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using ECommerce.Domain.Products;
using ECommerce.Domain.SeedWork;
using ECommerce.Domain.SharedKernel;

namespace ECommerce.Domain.Customers.Orders
{
    public class Order : Entity
    {
        internal OrderId Id;

        private bool _isRemoved;

        private decimal _price;

        private List<OrderProduct> _orderProducts;

        private OrderStatus _status;

        private DateTime _orderDate;

        private DateTime? _orderChangeDate;

        private Order()
        {
            this._orderProducts = new List<OrderProduct>();
            this._isRemoved = false;
        }

        private Order(
            List<OrderProductData> orderProductsData,
            List<ProductPriceData> productPrices
            )
        {
            this._orderDate = SystemClock.Now;
            this.Id = new OrderId(Guid.NewGuid());
            this._orderProducts = new List<OrderProduct>();

            foreach (var orderProductData in orderProductsData)
            {
                var productPrice = productPrices.Single(x => x.ProductId == orderProductData.ProductId);
                var orderProduct = OrderProduct.CreateForProduct(
                    productPrice, 
                    orderProductData.Quantity);

                _orderProducts.Add(orderProduct);
            }

            this.CalculateOrderValue();
            this._status = OrderStatus.Placed;
        }

        internal static Order CreateNew(List<OrderProductData> orderProductsData,
            List<ProductPriceData> allProductPrices)
        {
            return new Order(orderProductsData, allProductPrices);
        }

        internal void Change(
            List<ProductPriceData> allProductPrices,
            List<OrderProductData> orderProductsData)
        {
            foreach (var orderProductData in orderProductsData)
            {
                var product = allProductPrices.Single(x => x.ProductId == orderProductData.ProductId);
                
                var existingProductOrder = _orderProducts.SingleOrDefault(x => x.ProductId == orderProductData.ProductId);
                if (existingProductOrder != null)
                {
                    var existingOrderProduct = this._orderProducts.Single(x => x.ProductId == existingProductOrder.ProductId);
                    
                    existingOrderProduct.ChangeQuantity(product, orderProductData.Quantity);
                }
                else
                {
                    var orderProduct = OrderProduct.CreateForProduct(product, orderProductData.Quantity);
                    this._orderProducts.Add(orderProduct);
                }
            }

            var orderProductsToCheck = _orderProducts.ToList();
            foreach (var existingProduct in orderProductsToCheck)
            {
                var product = orderProductsData.SingleOrDefault(x => x.ProductId == existingProduct.ProductId);
                if (product == null)
                {
                    this._orderProducts.Remove(existingProduct);
                }
            }

            this.CalculateOrderValue();

            this._orderChangeDate = DateTime.UtcNow;
        }

        internal void Remove()
        {
            this._isRemoved = true;
        }

        internal bool IsOrderedToday()
        {
           return this._orderDate.Date == SystemClock.Now.Date;
        }


		internal decimal GetValue()
		{
			return _price;
		}

		private void CalculateOrderValue()
        {
            _price = _orderProducts.Sum(x => x.Price);
        }
    }
}
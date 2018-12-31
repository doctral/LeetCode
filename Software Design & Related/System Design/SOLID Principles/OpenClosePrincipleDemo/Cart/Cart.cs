using OpenClosePrincipleDemo.model;
using OpenClosePrincipleDemo.PriceCalulator;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenClosePrincipleDemo.Cart
{
	public class Cart
	{
		private readonly List<OrderItem> _items;
		private readonly IPriceCalculator _pricingCalculator;

		public Cart(IPriceCalculator pricingCalculator)
		{
			_pricingCalculator = pricingCalculator;
			_items = new List<OrderItem>();
		}

		public IEnumerable<OrderItem> Items
		{
			get { return _items; }
		}

		public string CustomerEmail { get; set; }

		public void Add(OrderItem orderItem)
		{
			_items.Add(orderItem);
		}

		public decimal TotalAmount()
		{
			decimal total = 0m;
			foreach (OrderItem orderItem in Items)
			{
				total += _pricingCalculator.CalculatePrice(orderItem);
			}
			return total;
		}
	}
}

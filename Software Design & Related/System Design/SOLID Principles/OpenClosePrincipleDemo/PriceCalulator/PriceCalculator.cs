using OpenClosePrincipleDemo.model;
using OpenClosePrincipleDemo.PriceRule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenClosePrincipleDemo.PriceCalulator
{
	public class PriceCalculator : IPriceCalculator
	{
		private readonly List<IPriceRule> _pricingRules;

		public PriceCalculator()
		{
			_pricingRules = new List<IPriceRule>();
			_pricingRules.Add(new EachPriceRule());
			_pricingRules.Add(new PerGramPriceRule());
			_pricingRules.Add(new SpecialPriceRule());
			_pricingRules.Add(new BuyFourGetOneFreePriceRule());
		}

		public decimal CalculatePrice(OrderItem item)
		{
			return _pricingRules.First(r => r.IsMatch(item)).CalculatePrice(item);
		}
	}
}

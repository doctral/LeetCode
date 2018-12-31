using OpenClosePrincipleDemo.model;

namespace OpenClosePrincipleDemo.PriceRule
{
	public class EachPriceRule : IPriceRule
	{
		public bool IsMatch(OrderItem item)
		{
			return item.Sku.StartsWith("EACH");
		}

		public decimal CalculatePrice(OrderItem item)
		{
			return item.Quantity * 5m;
		}
	}
}

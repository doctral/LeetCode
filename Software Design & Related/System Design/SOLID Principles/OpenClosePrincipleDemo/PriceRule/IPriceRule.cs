using OpenClosePrincipleDemo.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenClosePrincipleDemo.PriceRule
{
	public interface IPriceRule
	{
		bool IsMatch(OrderItem item);
		decimal CalculatePrice(OrderItem item);
	}
}

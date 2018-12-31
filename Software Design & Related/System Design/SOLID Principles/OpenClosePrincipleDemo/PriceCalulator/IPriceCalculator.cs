using OpenClosePrincipleDemo.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenClosePrincipleDemo.PriceCalulator
{
	public interface IPriceCalculator
	{
		decimal CalculatePrice(OrderItem item);
	}
}

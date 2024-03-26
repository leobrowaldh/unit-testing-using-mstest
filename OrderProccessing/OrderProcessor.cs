namespace OrderProccessing;

public class OrderProcessor
{
	private const decimal TaxRate = 0.07m; // 7% tax
	private const decimal ShippingCostPerItem = 5.00m;

	public decimal CalculateTotalCost(int numberOfItems, decimal pricePerItem)
	{
		decimal baseCost = BaseCost(numberOfItems, pricePerItem);
		decimal taxAmount = TaxAmount(baseCost);
		decimal shippingCost = ShippingCost(numberOfItems);
		decimal totalCost = baseCost + taxAmount + shippingCost;
		return totalCost;
	}

	private static decimal ShippingCost(int numberOfItems)
	{
		return numberOfItems * ShippingCostPerItem;
	}

	private static decimal TaxAmount(decimal baseCost)
	{
		return baseCost * TaxRate;
	}

	private static decimal BaseCost(int numberOfItems, decimal pricePerItem)
	{
		return numberOfItems * pricePerItem;
	}
}

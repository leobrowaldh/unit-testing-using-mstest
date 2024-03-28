using System.Net.Http.Headers;

namespace ShoppingCartApp;

public class ShoppingCart
{
	public decimal Discount { get; set; } = 0;
	public List<Product> Products { get; set; } = [];
	public Product AddProduct(string name, decimal price, int quantity)
	{
		Product addedProduct = new Product()
		{
			Name = name,
			Price = price,
			Quantity = quantity
		};
		Product? existingProduct = Products.FirstOrDefault(p => p.Name == name);
		if (existingProduct is not null)
		{
			existingProduct.Quantity += quantity;
			return existingProduct;
		}
		Products.Add(addedProduct);
		return addedProduct;
	}

	public bool RemoveProduct(string productName)
	{
		Product? productToRemove = Products.FirstOrDefault(p => p.Name == productName);
		if (productToRemove is not null)
		{
			Products.Remove(productToRemove);
			return true;
		}
		return false;
	}

	public decimal CalculateTotalPrice()
	{
		decimal total = 0;
		foreach (Product product in Products)
		{
			total += product.Price * product.Quantity;
		}
		return total * (1 - Discount);
	}

	public void ApplyDiscount(decimal porcentualDiscount)
	{
		Discount = porcentualDiscount/100;
	}


}

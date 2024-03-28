namespace ShoppingCartApp.Test
{
	[TestClass]
	public class CartTests
	{

		[TestMethod]
		public void AddProductThatDidNotExist()
		{
			//Arrange
			ShoppingCart cart = new ShoppingCart();

			//Act
			Product bananaProduct = cart.AddProduct("banana", 25.00M, 2);

			//Assert
			
			Assert.AreEqual(1, cart.Products.Count);
			Assert.AreEqual(2, cart.Products[0].Quantity);
		}

		[TestMethod]
		public void AddProductThatAllreadyExists()
		{
			//Arrange
			ShoppingCart cart = new ShoppingCart();
			Product bananaProduct1 = cart.AddProduct("banana", 25.00M, 2);

			//Act
			Product bananaProduct2 = cart.AddProduct("banana", 25.00M, 4);

			//Assert
			Assert.AreSame(bananaProduct1, bananaProduct2);
			Assert.AreEqual(6, bananaProduct1.Quantity);
		}

		[TestMethod]
		public void RemoveProduct()
		{
			//Arrange
			ShoppingCart cart = new ShoppingCart();
			Product bananaProduct1 = cart.AddProduct("banana", 25.00M, 2);

			//Act
			bool successfullRemoval = cart.RemoveProduct("banana");

			//Assert
			Assert.IsTrue(successfullRemoval);
			Assert.AreEqual(0, cart.Products.Count);
		}

		[TestMethod]
		public void RemoveProductThatDoesntExist()
		{
			//Arrange
			ShoppingCart cart = new ShoppingCart();
			Product bananaProduct1 = cart.AddProduct("banana", 25.00M, 2);

			//Act
			bool successfullRemoval = cart.RemoveProduct("Orange");

			//Assert
			Assert.IsFalse(successfullRemoval);
		}

		[TestMethod]
		public void CalculateTotalPriceWithTwoProducts()
		{
			//Arrange
			ShoppingCart cart = new ShoppingCart();
			Product bananaProduct = cart.AddProduct("banana", 25.00M, 2);
			Product orangeProduct = cart.AddProduct("orange", 55.00M, 1);

			//Act
			decimal total = cart.CalculateTotalPrice();

			//Assert
			Assert.AreEqual(105.00M, total);
		}

		[TestMethod]
		public void CalculateTotalPriceWithNoProducts()
		{
			//Arrange
			ShoppingCart cart = new ShoppingCart();

			//Act
			decimal total = cart.CalculateTotalPrice();

			//Assert
			Assert.AreEqual(0, total);
		}

		[TestMethod]
		public void DiscountShouldApplyCorrectly()
		{
			//Arrange
			ShoppingCart cart = new ShoppingCart();
			Product bananaProduct = cart.AddProduct("banana", 25.00M, 2);
			Product orangeProduct = cart.AddProduct("orange", 50.00M, 1);
			decimal total = cart.CalculateTotalPrice();

			//Act
			cart.ApplyDiscount(10);
			decimal discountedTotal = cart.CalculateTotalPrice();

			//Assert
			Assert.AreEqual(90.00M, discountedTotal);
		}

		[TestMethod]
		public void DiscountOneHundredProcent()
		{
			//Arrange
			ShoppingCart cart = new ShoppingCart();
			Product bananaProduct = cart.AddProduct("banana", 25.00M, 2);
			Product orangeProduct = cart.AddProduct("orange", 50.00M, 1);
			decimal total = cart.CalculateTotalPrice();

			//Act
			cart.ApplyDiscount(100);
			decimal discountedTotal = cart.CalculateTotalPrice();

			//Assert
			Assert.AreEqual(0.00M, discountedTotal);
		}
	}
}
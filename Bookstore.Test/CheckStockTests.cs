namespace Bookstore.Test;

[TestClass]
public class CheckStockTests
{
	[TestMethod]
	public void CheckStockOnUnexistingBook_ShouldReturnTrue()
	{
		//Arrange
		BookStoreInventory bookStoreInventory = new Bookstore.BookStoreInventory() { };
		Book testBook = new Book("idd34123412", "Lala", "Lolo", 1);

		//Act
		var result = bookStoreInventory.CheckStock(testBook.ISBN);

		//Assert
		Assert.AreEqual(result, 0);
	}

	[TestMethod]
	public void CheckStockReturnsExpctedStock_ShouldReturnTrue()
	{
		//Arrange
		BookStoreInventory bookStoreInventory = new Bookstore.BookStoreInventory() { };
		Book testBook = new Book("idd34123412", "Lala", "Lolo", 1);
		bookStoreInventory.AddBook(testBook);

		//Act
		var result = bookStoreInventory.CheckStock(testBook.ISBN);

		//Assert
		Assert.AreEqual(result, 1);
	}
}
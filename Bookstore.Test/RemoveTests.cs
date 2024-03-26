namespace Bookstore.Test;

[TestClass]
public class RemoveTests
{
	[TestMethod]
	public void RemovingUnexistingBook_shouldReturnFalse()
	{
		//Arrange
		BookStoreInventory bookStoreInventory = new Bookstore.BookStoreInventory() { };
		Book testBook = new Book("idd34123412", "Lala", "Lolo", 1);

		//Act
		var result = bookStoreInventory.RemoveBook(testBook.ISBN);

		//Assert
		Assert.IsFalse(result);
	}

	[TestMethod]
	public void RemoveExistingBookWithOneStock_ShouldReturnTrue_andHave0Stock()
	{
		//Arrange
		BookStoreInventory bookStoreInventory = new Bookstore.BookStoreInventory() { };
		Book testBook = new Book("idd34123412", "Lala", "Lolo", 1);
		bookStoreInventory.AddBook(testBook);

		//Act
		var result = bookStoreInventory.RemoveBook(testBook.ISBN);
		int bookStock = bookStoreInventory.CheckStock(testBook.ISBN);

		//Assert
		Assert.IsTrue(result);
		Assert.AreEqual(0, bookStock);
	}

	[TestMethod]
	public void RemoveExistingBookWithManyStocks_ShouldReturnTrue_andHaveOneLessStock()
	{
		//Arrange
		BookStoreInventory bookStoreInventory = new Bookstore.BookStoreInventory() { };
		Book testBook = new Book("idd34123412", "Lala", "Lolo", 5);
		bookStoreInventory.AddBook(testBook);

		//Act
		var result = bookStoreInventory.RemoveBook(testBook.ISBN);
		int bookStock = bookStoreInventory.CheckStock(testBook.ISBN);

		//Assert
		Assert.IsTrue(result);
		Assert.AreEqual(4, bookStock);
	}
}

using Bookstore;
namespace Bookstore.Test;

[TestClass]
public class AddTesting
{


	[TestMethod]
	public void ADdBook_BookDidNotExistBefore_ShouldReturnTrue()
	{
		//Arrange
		BookStoreInventory bookStoreInventory = new Bookstore.BookStoreInventory() { };
		Book testBook = new Book("idd34123412", "Lala", "Lolo", 1);

		//Act
		var result = bookStoreInventory.AddBook(testBook);
		var stock = bookStoreInventory.CheckStock(testBook.ISBN);

		//Assert
		Assert.IsTrue(result);
		Assert.AreEqual(stock, 1);
	}

	[TestMethod]
	public void AddBook_BookAllreadyExists_ShouldRestockAndReturnFalse()
	{
		//Arrange
		BookStoreInventory bookStoreInventory = new Bookstore.BookStoreInventory();
		Book testBook1 = new Book("idd34123412", "Lala", "Lolo", 1);
		bookStoreInventory.AddBook(testBook1);

		//Act  adding 3 more books, same isbn, nother instance
		Book testBook2 = new Book("idd34123412", "Lala", "Lolo", 3);
		var result = bookStoreInventory.AddBook(testBook2);
		var stock = bookStoreInventory.CheckStock(testBook1.ISBN);

		//Assert
		Assert.IsFalse(result);
		Assert.AreEqual(4, stock);
	}
}
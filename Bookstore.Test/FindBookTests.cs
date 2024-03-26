namespace Bookstore.Test;

[TestClass]
public class FindBooksTests
{
	[TestMethod]
	public void FindingUnexistingBook_ShouldReturnNull()
	{
		//Arrange
		BookStoreInventory bookStoreInventory = new Bookstore.BookStoreInventory() { };
		Book testBook = new Book("idd34123412", "Lala", "Lolo", 1);

		//Act
		var result = bookStoreInventory.FindBookByTitle(testBook.Title);

		//Assert
		Assert.IsNull(result);
	}

	[TestMethod]
	public void FindBook_Compare_ISBN_ShouldReturnNotNullAndTrue()
	{
		//Arrange
		BookStoreInventory bookStoreInventory = new Bookstore.BookStoreInventory() { };
		Book testBook = new Book("idd34123412", "Lala", "Lolo", 1);
		bookStoreInventory.AddBook(testBook);

		//Act
		var result = bookStoreInventory.FindBookByTitle(testBook.Title);

		//Assert
		Assert.IsNotNull(result);
		Assert.AreEqual(testBook.ISBN, result.ISBN);
	}
}
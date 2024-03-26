namespace OrderProccessing.Test
{
	[TestClass]
	public class RefactoringTests
	{	//Data rows cant use decimal, only double, damn! 
		[DataRow(0, 1000.00, 0.00)]
		[DataRow(2, 0.00, 10.00)]
		[DataRow(2, 10.00, 31.40)]
		[DataTestMethod]
		public void TestCalculateTotalCost_ShouldReturnTrue(int numberOfItems, double pricePerItem, double expectedTotal)
		{
			//Arrange
			OrderProcessor processor = new OrderProcessor();

			//Act
			decimal result = processor.CalculateTotalCost(numberOfItems, (decimal)pricePerItem);
			//Assert
			Assert.AreEqual(result, (decimal)expectedTotal);
		}
	}
}
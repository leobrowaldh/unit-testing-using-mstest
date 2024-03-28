namespace LoyaltyPointsCalculatorService.Test;

using Moq;

[TestClass]
public class LoyaltyServiceTests
{
	[TestMethod]
	public void JustTryingOutMoq()
	{
		var mockOrderRepository = new Mock<IOrderRepository>();
		mockOrderRepository.Setup(repo => repo.GetTotalAmountSpent("user123")).Returns(10);
		mockOrderRepository.Setup(repo => repo.GetTotalAmountSpent("user456")).Returns(200);

		Assert.AreEqual(10, mockOrderRepository.Object.GetTotalAmountSpent("user123"));
		Assert.AreEqual(200, mockOrderRepository.Object.GetTotalAmountSpent("user456"));
	}

	[TestMethod]
	public void CalculateLoyaltyPoints_HappyPath()
	{
		// Arrange
		var mockOrderRepository = new Mock<IOrderRepository>();
		var userId = "user123";
		var totalAmountSpent = 500m; // Assume the user spent $500
		var expectedPoints = totalAmountSpent * 0.1m; // Expected loyalty points
		mockOrderRepository.Setup(repo => repo.GetTotalAmountSpent(userId)).Returns(totalAmountSpent);

		var loyaltyService = new LoyaltyService(mockOrderRepository.Object);

		// Act
		var loyaltyPoints = loyaltyService.CalculateLoyaltyPoints(userId);

		// Assert
		Assert.AreEqual(expectedPoints, loyaltyPoints);
	}
}
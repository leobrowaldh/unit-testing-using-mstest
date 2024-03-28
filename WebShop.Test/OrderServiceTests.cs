namespace WebShop.Test;

using Castle.Core.Smtp;
using Moq;
using WebShopApp;

[TestClass]
public class OrderServiceTests
{
	[TestMethod]
	public void PlaceOrder_ShouldSendEmail()
	{
		//Arrange
		var mock = new Mock<IEmailService>();
		OrderService service = new OrderService(mock.Object);
		OrderDetails orderDetails = new OrderDetails()
		{
			OrderId = 666,
			CustomerEmail = "doom.slayer@hotmail.com"
		};

		//Act
		service.PlaceOrder(orderDetails);

		//Assert
		mock.Verify(es => es.SendEmail(orderDetails.CustomerEmail, "Order Confirmation", $"Thank you for your order! Order ID: {orderDetails.OrderId}"));
	}
}
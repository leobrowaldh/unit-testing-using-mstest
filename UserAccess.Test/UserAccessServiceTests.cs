namespace UserAccess.Test;
using Moq;
using UserAccess;
using static UserAccess.UserAccessService;

[TestClass]
public class UserAccessServiceTests
{
	[DataTestMethod]
	[DataRow(8, 59, 59, false)]
	[DataRow(9, 0, 0, true)]
	[DataRow(10, 0, 0, true)]
	[DataRow(16, 59, 59, true)]
	[DataRow(17, 0, 0, false)]
	public void IsAccessAllowed_ShouldReturnFalseBefore9(int hours, int minutes, int seconds, bool expectedResult)
	{
		//Arrange
		Mock<ITimeProvider> mock = new Mock<ITimeProvider>();
		mock.Setup(tp => tp.GetCurrentTime()).Returns(new DateTime(1980, 12, 3, hours, minutes, seconds));
		UserAccessService service = new UserAccessService(mock.Object);

		//Act
		bool isAllowed = service.IsAccessAllowed();

		//Assert
		Assert.AreEqual(expectedResult, isAllowed);
	}
}
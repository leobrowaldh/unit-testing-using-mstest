namespace UserRegistrations.Test
{
	[TestClass]
	public class CaseSensitiveTest
	{
		[TestMethod]
		public void TestingSameUsernameUppercase_ShouldReturnFalse()
		{
			//Arrange
			UserRegistration userRegistration = new UserRegistration();
			string oldUsername = "daUser";
			userRegistration.RegisterUser(oldUsername);

			//Act
			string newUSername = "DaUSer";
			bool result = userRegistration.RegisterUser(newUSername);

			//Assert
			Assert.IsFalse(result);
		}
	}
}
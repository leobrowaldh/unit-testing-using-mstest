namespace TravelAdvisorApp
{
	public class CountryInfo
	{
		public string CountryCode { get; set; }
		public string TravelRestrictions { get; set; }
		public string VaccinationRequirements { get; set; }
	}

	public interface ICountryInfoService
	{
		CountryInfo GetCountryInfo(string countryCode);
	}

	public interface INotificationService
	{
		void SendNotification(string userId, string message);
	}

	public class TravelAdvisorService
	{
		private readonly ICountryInfoService _countryInfoService;
		private readonly INotificationService _notificationService;

		public TravelAdvisorService(ICountryInfoService countryInfoService, INotificationService notificationService)
		{
			_countryInfoService = countryInfoService;
			_notificationService = notificationService;
		}

		public void ProvideTravelAdvice(string userId, string countryCode)
		{
			var countryInfo = _countryInfoService.GetCountryInfo(countryCode);
			var message = "";
			if(countryInfo is null)
			{
				message = $"No country info found for country code {countryCode}";
			}
			else
			{
				message = $"Travel Advice for {countryCode}: {countryInfo.TravelRestrictions}. Vaccinations: {countryInfo.VaccinationRequirements}.";
			}

			_notificationService.SendNotification(userId, message);
		}
	}
}

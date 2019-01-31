using static WebCore.Factories.WebDriverFactory;

namespace WebCore.Config
{
	public class Settings
	{
	   public static BrowserType BrowserType{ get; set; }

	   public static string Enviroment { get; set; }

		public static string Username { get; set; }

		public static string Password { get; set; }

		public static string BaseUrl { get; set; }
	}
}

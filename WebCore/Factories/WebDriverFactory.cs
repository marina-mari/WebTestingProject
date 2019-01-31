using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCore.Factories
{
   public class WebDriverFactory
	{
		public static IWebDriver driver { get; private set; }
		private static readonly IDictionary<BrowserType, IWebDriver> Drivers = new Dictionary<BrowserType, IWebDriver>();
		public enum BrowserType
		{
			Chrome,
			IE
		}

		public static BrowserType ReturnBrowserType(string type)
		{
			switch (type.ToLower())
			{
				case "chrome":
					return BrowserType.Chrome;
				case "ie":
					return BrowserType.IE;
				default:
					return BrowserType.Chrome;
			}
		}

		public static void InitBrowser(BrowserType browserName)
		{
			var options = new ChromeOptions();
			options.AddArgument("no-sandbox");
			try
			{
				Drivers.Remove(browserName);
				Drivers.Clear();
			}
			catch (Exception ex) { }

			switch (browserName)
			{
				case BrowserType.Chrome:
					driver = new ChromeDriver(options);
					Drivers.Add(BrowserType.Chrome, driver);
					break;
				case BrowserType.IE:
					var optionsIE = new InternetExplorerOptions
					{
						IgnoreZoomLevel = true
					};
					driver = new InternetExplorerDriver(optionsIE);
					Drivers.Add(BrowserType.IE, driver);
					break;
				default:
					driver = new ChromeDriver(options);
					Drivers.Add(BrowserType.Chrome, driver);
					break;
			}
		}

		public static void CloseDriver(BrowserType browserType)
		{
			if (Drivers.ContainsKey(browserType))
			{
				var driver = Drivers[browserType];
				driver.Close();
				driver.Quit();
				driver.Dispose();
			}
			Drivers.Clear();
			driver = null;
		}

		public static void CloseAllDrivers()
		{
			foreach (var key in Drivers.Keys)
			{
				var driver = Drivers[key];
				driver.Close();
				driver.Quit();
				driver.Dispose();
			}
			Drivers.Clear();
			driver = null;
		}
	}
}

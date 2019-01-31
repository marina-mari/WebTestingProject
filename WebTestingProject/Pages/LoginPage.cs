using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WebCore.BasePages;
using WebCore.Config;

namespace WebTestingProject.Pages
{
	public class LoginPage : BasePage
	{
		public string Url = "/drive";

		public LoginPage(IWebDriver driver) : base(driver)
		{
		}

		public void GoTo(string Url)
		{
			driver.Url = Settings.BaseUrl + Url;
			try
			{
				driver.Manage().Window.Maximize();
			}
			catch (Exception ex) { Console.WriteLine(ex); }
		}
	}
}

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using System.Linq;
using WebCore.Config;

namespace WebCore.BasePages
{
	public class BasePage : IPageObject
	{
		protected IWebDriver driver;
		protected WebDriverWait wait;
		protected string Url;
		string oldWindow;

		public BasePage(IWebDriver driver)
		{
			this.driver = driver;
			this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
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

		public void OpenNewWindowInBrowser()
		{
			// oldWindow - the window where client Manget app is running
			oldWindow = driver.CurrentWindowHandle;
			var jse = (IJavaScriptExecutor)driver;
			jse.ExecuteScript("window.open()");
			var windowHandlers = driver.WindowHandles;
			// newWindow - the window where admin Magnet app is running
			var newWindow = driver.WindowHandles.ToList<string>().Find(x => x != oldWindow);
			driver.SwitchTo().Window(newWindow);
		}

		public void SwitchToOldWindowInBrowser()
		{
			// oldWindow - the window where client Manget app is running
			if (oldWindow == null) { throw new NotImplementedException(); }
			driver.SwitchTo().Window(oldWindow);
		}
	}
}
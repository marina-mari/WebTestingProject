using TechTalk.SpecFlow;
using WebCore.Config;
using WebCore.Factories;
using WebTestingProject.Pages;

namespace WebTestingProject.Hooks
{
	[Binding]
	public class BasicHooks
	{
		public BasicHooks()
		{
			ConfigReader.SetFrameworkSettings();
		}

		[BeforeScenario(Order = 2)]
		public void BeforeScenario1()
		{
			WebDriverFactory.InitBrowser(Settings.BrowserType);
			Init.PageFactory = new PageObjectFactory(WebDriverFactory.driver);
		}

		[BeforeScenario(Order = 3)]
		public void BeforeScenario2()
		{
			LoginPage loginPage = Init.PageFactory.CreateInstance<LoginPage>();
			loginPage.GoTo(loginPage.Url);
		}
	}
}

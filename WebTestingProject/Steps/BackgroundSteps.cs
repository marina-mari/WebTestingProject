using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WebCore.Factories;
using WebTestingProject.Pages;

namespace WebTestingProject.Steps
{
	[Binding]
	public class BackgroundSteps : TechTalk.SpecFlow.Steps
	{
		LoginPage loginPage { get; set; }

		public BackgroundSteps()
		{
			loginPage = Init.PageFactory.CreateInstance<LoginPage>();
	    }

		[Given(@"I go to login page")]
		public void GivenIGoToLoginPage()
		{
			
		}

	}
}

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCore.BasePages;

namespace WebCore.Factories
{
	public class PageObjectFactory
	{
		readonly IWebDriver driver;

		public PageObjectFactory(IWebDriver driver)
		{
			this.driver = driver;
		}

		public T CreateInstance<T>() where T : IPageObject
		{
			return (T)Activator.CreateInstance(typeof(T), driver);
		}
	}
}

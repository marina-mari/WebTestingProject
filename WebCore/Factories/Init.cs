using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCore.Factories
{
	public class Init
	{
		public static PageObjectFactory PageFactory = new PageObjectFactory(WebDriverFactory.driver);
	}
}

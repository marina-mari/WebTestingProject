using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using WebCore.Factories;

namespace WebCore.Config
{
	public class ConfigReader
	{
		public static void SetFrameworkSettings()
		{
			var env = "";
			WebAutotests set;

			XmlDocument doc = new XmlDocument();
			doc.LoadXml(Resources.Resource.GlobalConfig);
			env = Environment.GetEnvironmentVariable("TEST_ENV");

			if (string.IsNullOrEmpty(env)) env = "QA";

			XmlSerializer serializer = new XmlSerializer(typeof(WebAutotests));
			using (XmlReader reader = new XmlNodeReader(doc))
			{
				set = (WebAutotests)serializer.Deserialize(reader);
			}

			if (env == "QA")
			{
				var baseEnv = set.QA;

				Settings.BrowserType = WebDriverFactory.ReturnBrowserType(baseEnv.RunSettings.Browser);
				Settings.Enviroment = baseEnv.RunSettings.Environment;
				Settings.Username = baseEnv.RunSettings.Username;
				Settings.Password = baseEnv.RunSettings.Password;
				Settings.BaseUrl = baseEnv.RunSettings.BaseUrl;
			}

			if (env == "DEV")
			{
				var baseEnv = set.DEV;

				Settings.BrowserType = WebDriverFactory.ReturnBrowserType(baseEnv.RunSettings.Browser);
				Settings.Enviroment = baseEnv.RunSettings.Environment;
				Settings.Username = baseEnv.RunSettings.Username;
				Settings.Password = baseEnv.RunSettings.Password;
				Settings.BaseUrl = baseEnv.RunSettings.BaseUrl;
			}


		}
	}
}

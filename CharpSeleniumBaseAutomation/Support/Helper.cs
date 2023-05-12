using Newtonsoft.Json.Linq;
using OpenQA.Selenium;

namespace NavigationSpecflowSelenium.Support
{
    public class Helper
    {
        //private static Dictionary<string, string> config = new Dictionary<string, string>() {
        //    {"env", "staging"},
        //    {"apiEnv", "sprint"},
        //    {"browser", "chrome"},
        //    {"url", "https://test.staging.safeschools.com/"},
        //    {"safeSchoolsUrl", "http://test.{0}.safeschools.com"},
        //    {"credentials.user", "user_automation"},
        //    {"credentials.password", "admin_automation"},
        //};

        public static IWebDriver driver = null!;
        public enum Browser
        {
            CHROME,
            EDGE,
            FIREFOX,
            SAFARI,
            OPERA
        }

        //public enum TrueOrFalse
        //{
        //    True,
        //    False
        //}

        //public enum TrueOrFalseES
        //{
        //    Verdadero,
        //    Falso
        //}

        //public static string GetValueFromConfigFile(string key)
        //{
        //    string configPath = Directory.GetCurrentDirectory() + @"/config.json";
        //    string json = string.Empty;

        //    using (StreamReader r = new(configPath))
        //    {
        //        json = r.ReadToEnd();
        //    }

        //    var details = JObject.Parse(json);

        //    return details.SelectToken(key)!.ToString();
        //}

        //public static string GetValueFromConfig(string key)
        //{
        //    return config[key];
        //}

        //public static string SetValueToConfig(string key, string value)
        //{
        //    return config[key] = value;
        //}
    }
}

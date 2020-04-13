using System.Configuration;

namespace EAAutoFramework.ConfigElement
{
    public class EATestConfiguration: ConfigurationSection
    {
        private static EATestConfiguration _testConfig = (EATestConfiguration)ConfigurationManager.GetSection("EATestConfiguration");

        public static EATestConfiguration EASettings => _testConfig;

        [ConfigurationProperty("testSettings")]
        public EAFrameworkElementCollection TestSettings => (EAFrameworkElementCollection)base["testSettings"];

    }
}

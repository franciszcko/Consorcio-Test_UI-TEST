using System.Configuration;

namespace EAAutoFramework.ConfigElement
{
    [ConfigurationCollection(typeof(EAFrameworkElement), AddItemName = "testSetting", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class EAFrameworkElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new EAFrameworkElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as EAFrameworkElement).Name;
        }

        public new EAFrameworkElement this[string type] => (EAFrameworkElement)base.BaseGet(type);
    }
}

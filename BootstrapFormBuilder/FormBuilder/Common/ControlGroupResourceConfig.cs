using System.Collections.Generic;
using System.Xml.Linq;

namespace FormBuilder.Common
{
    public static class ControlGroupResourceConfig
    {
        private static Dictionary<string, string> _resourceDictionary;
        const string ControlResourceConfig = @"../App_Data/FormControlResourceConfig.xml";
        static ControlGroupResourceConfig()
        {
            _resourceDictionary = new Dictionary<string, string>();
            XElement resourcElements = XElement.Load(ControlResourceConfig);
            foreach (var element in resourcElements.Elements())
            {
                //var id = element.Attribute("Id").Value;
                var key = element.Attribute("Key").Value;
                var path = element.Attribute("Path").Value;
                _resourceDictionary.Add(key, path);
            }
        }

        public static string GetControlGroupByKey(string key)
        {
            if (_resourceDictionary != null)
            {
                if (_resourceDictionary.ContainsKey(key))
                {
                    return _resourceDictionary[key];
                }
            }
            return string.Empty;
        }
    }
}
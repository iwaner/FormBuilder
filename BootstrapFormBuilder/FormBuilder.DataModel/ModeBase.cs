using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace FormBuilder.DataModel
{
    public abstract class ModeBase
    {
        
    }

    public static class ModeBaseExtension
    {
        public static string ToJason<T>(this ModeBase modeBase, List<T> oList)
        {
            string result;
            if (oList == null || oList.Count == 0)
                return string.Empty;
            try
            {
                result = JsonConvert.SerializeObject(oList, Formatting.None);
            }
            catch (Exception)
            {
                result = string.Empty;
            }
            return result;
        }

        public static List<T> ToModelBaseObject<T>(this string jsonString)
        {
            if (string.IsNullOrEmpty(jsonString))
            {
                return null;
            }
            List<T> results;
            try
            {
                results = JsonConvert.DeserializeObject<List<T>>(jsonString);
            }
            catch (Exception)
            {
                results = null;
            }
            return results;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVladimirPak
{
    public class Helper
    {
        //Helper method for getting properties names of the object
        public List<string> GetPropertiesNameOfClass(object pObject)
        {
            List<string> propertyList = new List<string>();
            if (pObject != null)
            {
                foreach (var prop in pObject.GetType().GetProperties())
                {
                    propertyList.Add(prop.Name);
                }
            }
            return propertyList;
        }

        //Helper to check object is null, empty string or any object's property is null
        public bool AnyNullOrEmpty(object obj)
        {
            return obj == null
                || obj.ToString() == ""
                || obj.GetType().GetProperties().Any(x => x.GetValue(obj) == null);

        }
    }
}

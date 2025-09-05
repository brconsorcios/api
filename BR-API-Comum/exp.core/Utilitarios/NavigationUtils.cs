using System.Collections.Specialized;
using System.Web.Routing;

namespace exp.core.Utilitarios
{
    public static class NavigationUtils
    {
        public static RouteValueDictionary ToRouteValues(this NameValueCollection col, object obj)
        {
            var values = new RouteValueDictionary(obj);
            if (col != null)
                foreach (string key in col)
                    //values passed in object override those already in collection
                    if (!values.ContainsKey(key))
                        values[key] = col[key];

            return values;
        }
    }
}
using CodeSquirl.RecipeApp.Model;
using System;
using System.Collections.Generic;

namespace CodeSquirl.RecipeApp.API
{
    public static class Enum<T> where T : IConvertible
    {
        public static IEnumerable<KeyValuePair<int, string>> ToKeyValuePairCollection()
        {
            var result = new List<KeyValuePair<int, string>>();
            var type = typeof(T);
            var values = Enum.GetValues(type);
            var index = 0;

            foreach(var item in values)
            {
                result.Add(new KeyValuePair<int, string>(index, item.ToString()));
                index++;
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;

namespace CoreWebAngularApp.Extensions
{
    public static class XplicitExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
            {
                action(item);
            }
        }

        // http://www.extensionmethod.net/2067/csharp/ienumerable-t/foreach-3
        // https://www.codeproject.com/Articles/991610/ForEach-LINQ-Extension
    }
}
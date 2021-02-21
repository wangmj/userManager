using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace wmj.userManagerServer.Infra
{
    public static class ObjectHelper
    {
        public static void CopyPropertyToTarget(object source, object target, IEnumerable<string> excepts = null)
        {
            string[] exs;
            if (excepts == null)
                exs = new string[] { };
            else
                exs = excepts as string[] ?? excepts.ToArray();
            var properties = source.GetType().GetProperties();
            IgnoreCaseStringComparer comparer = new IgnoreCaseStringComparer();
            foreach (PropertyInfo property in properties)
            {
                if (exs.Contains(property.Name, comparer)) continue;
                if (!property.CanRead) continue;
                var p = target.GetType().GetProperty(property.Name, BindingFlags.SetProperty | BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (p == null || !p.CanWrite) continue;
                var value = property.GetValue(source);
                p.SetValue(target, value);
            }
        }

        private class IgnoreCaseStringComparer : IEqualityComparer<string>
        {
            public bool Equals(string x, string y)
            {
                return x.Equals(y, StringComparison.CurrentCultureIgnoreCase);
            }

            public int GetHashCode(string obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}

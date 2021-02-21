using System;
using System.Linq;
using System.Security.Claims;

namespace wmj.userManagerServer.Infra
{
    public static class ClaimsHelper
    {
        public static T Get<T>(this ClaimsPrincipal claims, string typeName, Func<string, T> converter)
        {
            string result = claims.Claims.Where(x => typeName.Equals(x.Type)).Select(x => x.Value).FirstOrDefault();
            if (string.IsNullOrWhiteSpace(result))
                return default(T);
            if (converter == null)
                throw new ArgumentNullException(nameof(converter));
            return converter(result);
        }

        public static T Get<T>(this ClaimsPrincipal claims, string typeName)
        {
            return claims.Get(typeName, str => (T)Convert.ChangeType(str, typeof(T)));
        }
    }
}

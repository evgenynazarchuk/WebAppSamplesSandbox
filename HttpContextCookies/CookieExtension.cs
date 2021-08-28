using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace HttpContextCookies
{
    public static class CookieExtension
    {
        public static void Append<TypeInput>(this IResponseCookies cookie, string key, TypeInput @object)
        {
            string objectString = JsonSerializer.Serialize(@object);
            cookie.Append(key, objectString);
        }

        public static bool TryGetValue<TypeOutput>(this IRequestCookieCollection cookie, string key, out TypeOutput @object)
        {
            bool result = cookie.TryGetValue(key, out string value);
            if (result)
            {
                @object = JsonSerializer.Deserialize<TypeOutput>(value);
            }
            else
            {
                @object = default;
            }

            return result;
        }
    }
}

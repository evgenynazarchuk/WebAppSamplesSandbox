using Microsoft.AspNetCore.Http;
using System.Text;
using System.Text.Json;

namespace HttpContextSession
{
    public static class SessionExtension
    {
        public static ISession SetObject<TypeInput>(this ISession session, string key, TypeInput @object)
        {
            string objectString = JsonSerializer.Serialize<TypeInput>(@object);
            session.SetString(key, objectString);
            return session;
        }

        public static TypeOutput GetObject<TypeOutput>(this ISession session, string key)
        {
            string objectString = session.GetString(key);
            TypeOutput @object = JsonSerializer.Deserialize<TypeOutput>(objectString);
            return @object;
        }
    }
}

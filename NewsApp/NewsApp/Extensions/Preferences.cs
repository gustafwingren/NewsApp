using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace NewsApp.Extensions
{
    public static class Preferences
    {
        public static T GetValueOrDefault<T>(string key, T @default) where T : class
        {
            string serialized = Xamarin.Essentials.Preferences.Get(key, string.Empty);
            T result = @default;

            try
            {
                JsonSerializerSettings serializeSettings = GetSerializerSettings();
                result = JsonConvert.DeserializeObject<T>(serialized);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error deserializing preferences value: {ex}");
            }

            return result;
        }

        public static bool AddOrUpdateValue<T>(string key, T obj) where T : class
        {
            try
            {
                JsonSerializerSettings serializerSettings = GetSerializerSettings();
                string serialized = JsonConvert.SerializeObject(obj, serializerSettings);

                Xamarin.Essentials.Preferences.Set(key, serialized);

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error serializing preferences value: {ex}");
            }

            return false;
        }

        private static JsonSerializerSettings GetSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }
    }
}

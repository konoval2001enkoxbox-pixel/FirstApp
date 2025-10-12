using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp.View.Security
{
    public static class Storage
    {
        public const string TOKEN = "token";
        public static void ClearSecureStorage()
        {
            try
            {
                SecureStorage.Remove(TOKEN);
                SecureStorage.RemoveAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clearing storage: {ex.Message}");
            }
        }
        public static string? Get(string key)
        {
            try
            {
                return Task.Run(() => SecureStorage.GetAsync(key)).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clearing storage: {ex.Message}");
                return default;
            }
        }
        public static bool Set(string key, string value)
        {
            var res = false;
            try
            {
                return Task.Run(() => { SecureStorage.SetAsync(key, value); return true; }).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clearing storage: {ex.Message}");
            }
            return res;
        }
    }
}

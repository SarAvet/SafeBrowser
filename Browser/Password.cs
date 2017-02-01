using Microsoft.Win32;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Browser
{
    class Password
    {
        static string[] path = { "Browser", "UserData" };
        static string valueName = "key";

        static RegistryKey registry = Registry.CurrentUser.CreateSubKey(path[0]).CreateSubKey(path[1]);

        static public void Set(string password)
        {
             registry.SetValue(valueName, GetHash(password));
        }

        static public string Get()
        {
            if (Exist())
                return (string)registry.GetValue(valueName);

            return null;
        }

        static public bool Exist()
        {
            if (registry.ValueCount == 0)
                registry.SetValue(valueName, "");

            return !registry.GetValue(valueName).Equals("");
        }

        static public string GetHash(string password)
        {
            SHA512 sha512 = new SHA512Managed();
            return BitConverter.ToString(sha512.ComputeHash(Encoding.UTF8.GetBytes(password))).Replace("-", "");
        }

    
    }
}

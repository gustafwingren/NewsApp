using NewsApp.Extensions;
using NewsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp
{
    public static class AppSettings
    {
        public static User User
        {
            get => Preferences.GetValueOrDefault(nameof(User), default(User)); 
            set => Preferences.AddOrUpdateValue(nameof(User), value);
        }

        public static void RemoveUserData()
        {
            Xamarin.Essentials.Preferences.Remove(nameof(User));
        }
    }
}

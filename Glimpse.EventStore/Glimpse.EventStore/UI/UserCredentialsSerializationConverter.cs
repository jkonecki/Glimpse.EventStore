using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using EventStore.ClientAPI.SystemData;
using Glimpse.Core.Extensibility;

namespace Glimpse.EventStore.UI
{
    class UserCredentialsSerializationConverter : SerializationConverter<UserCredentials>
    {
        public const string AppSettingsKey = "Glimpse.EventStore:HideUserCredentialsPassword";

        public override object Convert(UserCredentials obj)
        {
            var hidePassword = string.Compare(ConfigurationManager.AppSettings.Get(AppSettingsKey), bool.TrueString, true) == 0;

            return new 
            {
                obj.Login, 
                Password = hidePassword ? "****" : obj.Password
            };
        }
    }
}

using System;

namespace Routindo.Contract
{
    public class PluginUtilities
    {
        private static readonly PluginUtilities Instance;

        private static readonly object InstanceSyncObj = new object();

        static PluginUtilities()
        {
            if (Instance != null)
                return;

            lock (InstanceSyncObj)
            {
                if (Instance != null)
                    return;

                Instance = new PluginUtilities();
            }
        }

        private PluginUtilities()
        {
        }

        public static string GetUniqueId()
        {
            return Instance.GenerateUniqueId().ToUpper();
        }

        private string GenerateUniqueId()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
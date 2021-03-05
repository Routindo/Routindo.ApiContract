using System;

namespace Umator.Contract.Services
{
    public interface IServicesProvider
    {
        ILoggingService GetLoggingService(string name, Type type = null);
    }

    public class ServicesContainer 
    {
        public static IServicesProvider ServicesProvider { get; internal set; }

        private static readonly ServicesContainer Instance;

        private static readonly object SyncObj = new object();

        private ServicesContainer()
        {

        }

        static ServicesContainer()
        {
            if(Instance != null)
                return;

            lock (SyncObj)
            {
                if(Instance != null)
                    return;

                Instance = new ServicesContainer();
            }
        }
    }
}

namespace Routindo.Contract.Services
{
    public class ServicesContainer 
    {
        public static IServicesProvider ServicesProvider { get; internal set; }

        private static readonly ServicesContainer Instance;

        private static readonly object SyncObj = new object();

        private ServicesContainer()
        {

        }

        public static void SetServicesProvider(IServicesProvider servicesProvider)
        {
            ServicesProvider = servicesProvider;
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
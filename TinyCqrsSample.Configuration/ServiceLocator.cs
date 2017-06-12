using StructureMap;
using TinyCqrsSample.Core.Messaging;
using TinyCqrsSample.Core.Reporting;

namespace TinyCqrsSample.Configuration
{
    public class ServiceLocator
    {
        private static readonly ICommandBus _commandBus;
        private static readonly IReportDatabase _reportDatabase;
        private static readonly bool IsInitialized;
        private static readonly object LockThis = new object();

        static ServiceLocator()
        {
            if(!IsInitialized)
            {
                lock(LockThis)
                {
                    ContainerBootstrapper.BootstrapStructureMap();
                    _commandBus = ObjectFactory.GetInstance<ICommandBus>();
                    _reportDatabase = ObjectFactory.GetInstance<IReportDatabase>();
                    IsInitialized = true;
                }
            }
        }

        public static ICommandBus CommandBus
        {
            get { return _commandBus; }
        }

        public static IReportDatabase ReportDatabase
        {
            get { return _reportDatabase; }
        }
    }
}

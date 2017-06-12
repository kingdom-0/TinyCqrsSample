using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using TinyCqrsSample.Core.CommandHandlers;
using TinyCqrsSample.Core.Commands;

namespace TinyCqrsSample.Core.Utils
{
    public class StructureMapCommandHandlerFactory : ICommandHandlerFactory
    {
        public ICommandHandler<T> GetHandlers<T>() where T : Command
        {
            var handlers = GetHandlerTypes<T>().ToList();
            var commandHandler = handlers.Select(handler => 
            (ICommandHandler<T>)ObjectFactory.GetInstance(handler)).FirstOrDefault();

            return commandHandler;
        }

        private static IEnumerable<Type> GetHandlerTypes<T>() where T : Command
        {
            var handlers = typeof(ICommandHandler<>).Assembly.GetExportedTypes()
                .Where(x => x.GetInterfaces()
                .Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(ICommandHandler<>)))
                .Where(h => h.GetInterfaces()
                .Any(ii => ii.GetGenericArguments().Any(aa => aa == typeof(T)))).ToList();

            return handlers;   
        }
    }
}

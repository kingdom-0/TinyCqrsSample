using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using TinyCqrsSample.Core.EventHandlers;
using TinyCqrsSample.Core.Events;

namespace TinyCqrsSample.Core.Utils
{
    public class StructureMapEventHandlerFactory:IEventHandlerFactory
    {
        public IEnumerable<IEventHandler<T>> GetHandlers<T>() where T : Event
        {
            var handlerTypes = GetHandlerType<T>();
            var handlers = handlerTypes.Select(t => (IEventHandler<T>)ObjectFactory.GetInstance(t))
                .ToList();

            return handlers;
        }

        private static IEnumerable<Type> GetHandlerType<T>() where T :Event
        {
            var handlers = typeof(IEventHandler<>).Assembly.GetExportedTypes()
                .Where(x => x.GetInterfaces().Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(IEventHandler<>)))
                .Where(a => a.GetInterfaces().Any(ii => ii.GetGenericArguments().Any(aa => aa == typeof(T)))).ToList();

            return handlers;
        }
    }
}

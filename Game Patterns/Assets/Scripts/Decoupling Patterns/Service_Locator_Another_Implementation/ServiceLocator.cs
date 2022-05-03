using System.Collections.Generic;
using System.Linq;

namespace Decoupling_Patterns.Service_Locator_Another_Implementation
{
    public static class ServiceLocator
    {
        private static readonly HashSet<object> RegisteredObjects;

        static ServiceLocator()
        {
            RegisteredObjects = new HashSet<object>();
        }

        public static void Register<T>(T obj) where T : class
        {
            RegisteredObjects.Add(obj);
        }

        public static void Unregister<T>(T obj) where T : class
        {
            RegisteredObjects.Remove(obj);
        }

        public static T Resolve<T>() where T : class
        {
            var obj = RegisteredObjects.SingleOrDefault(x => x is T);
            if (obj != null) return obj as T;
            return null;
        }
    }
}

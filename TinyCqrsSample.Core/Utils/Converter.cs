using System;

namespace TinyCqrsSample.Core.Utils
{
    public static class Converter
    {
        public static Action<object> Convert<T>(Action<T> actionT)
        {
            if(actionT == null)
            {
                return null;
            }

            return o => actionT((T)o);
        }

        public static dynamic ChangeTo(dynamic source, Type dest)
        {
            return System.Convert.ChangeType(source, dest);
        }
    }
}

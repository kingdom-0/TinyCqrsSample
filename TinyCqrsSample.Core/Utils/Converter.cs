﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return new Action<object>(o => actionT((T)o));
        }

        public static dynamic ChangeTo(dynamic source, Type dest)
        {
            return System.Convert.ChangeType(source, dest);
        }
    }
}

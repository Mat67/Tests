using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Data
{
    public static class Catalogue
    {
        public static List<T> OfType<T>()
        {
            return _Datas.OfType<T>().ToList();
        }

        public static void Clear()
        {
            _Datas.Clear();
        }

        static List<object> _Datas = new List<object>();
    }
}

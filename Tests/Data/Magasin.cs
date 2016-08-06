using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Data
{
    public static class Magasin
    {
        public static IEnumerable<T> OfType<T>()
        {
            return _Datas.OfType<T>();
        }

        public static void Populate<T>(IList<T> datas)
        {
            _Datas.AddRange(datas.Cast<object>());
        }

        public static void Populate<T>(IEnumerable<T> datas)
        {
            _Datas.AddRange(datas.Cast<object>());
        }

        public static void Populate<T>(T data)
        {
            _Datas.Add(data);
        }

        public static void Clear()
        {
            _Datas.Clear();
        }

        static List<object> _Datas = new List<object>();
    }
}

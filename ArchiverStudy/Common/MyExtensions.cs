using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiverStudy.Common
{
    public static class MyExtensions
    {
        public static string Join<T>(this IEnumerable<T> self, string separator = ",", string begin = "", string end = "") =>
            begin + string.Join(separator, self) + end;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIS
{
    public static class Extensions
    {
        public static int ToInt32(this object line)
        {
            return int.Parse(line.ToString());
        }

        public static long ToInt64(this object line)
        {
            return long.Parse(line.ToString());
        }

        public static short ToInt16(this object line)
        {
            return short.Parse(line.ToString());
        }

        public static byte ToInt8(this object line)
        {
            return byte.Parse(line.ToString());
        }
    }
}

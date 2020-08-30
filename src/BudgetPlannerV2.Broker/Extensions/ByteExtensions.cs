using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerV2.Broker.Extensions
{
    public static class ByteExtensions
    {
        public static string GetString(this IEnumerable<byte> bytes, Encoding encoding)
        {
            return encoding.GetString(bytes.ToArray());
        }

        public static IEnumerable<byte> GetBytes(this string value, Encoding encoding)
        {
            return encoding.GetBytes(value);
        }
    }
}

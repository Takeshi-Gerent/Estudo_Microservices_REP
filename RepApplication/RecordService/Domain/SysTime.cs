using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecordService.Domain
{
    public class SysTime
    {
        public static Func<DateTime> CurrentTimeProvider { get; set; } = () => DateTime.Now;
        public static Func<DateTime> CurrentUtcTimeProvider { get; set; } = () => DateTime.UtcNow;
        public static DateTime CurrentTime => CurrentTimeProvider();
        public static DateTime CurrentUtcTime => CurrentUtcTimeProvider();
        
    }
}

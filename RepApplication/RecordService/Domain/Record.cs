using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecordService.Domain
{
    public class Record
    {
        public virtual long Id { get; protected set; }
        public virtual DateTime RecordInstant { get; protected set; }
        public virtual DateTime RecordInstantUTC { get; protected set; }
        public virtual int TimeZone { get; protected set; }        
        public virtual bool DaylightSavingTime { get; protected set; }        
        public virtual Employee Employee{ get; protected set; }

        protected Record() { }

        private Record(DateTime recordInstantUTC, int timeZone, bool daylightSavingTime)
        {
            Id = 0;            
            RecordInstantUTC = recordInstantUTC;
            TimeZone = timeZone;
            DaylightSavingTime = daylightSavingTime;
        }

        public static Record New(DateTime recordInstantUTC, int timeZone, bool daylightSavingTime, Employee employee)
        {
            var record = new Record(recordInstantUTC, timeZone, daylightSavingTime);
            record.SetRecordInstant();
            record.SetEmployee(employee);
            return record;
        }

        private void SetRecordInstant()
        {
            RecordInstant = RecordInstantUTC.Add(GetTimeZoneInfo().GetUtcOffset(RecordInstantUTC));
        }

        private void SetEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentException("Funcionário não pode ser nulo.");
            }
            Employee = employee;
        }

        private TimeZoneInfo GetTimeZoneInfo()
        {
            var baseUtcOffSet = new TimeSpan(TimeZone, minutes: 0, seconds: 0);
            if (DaylightSavingTime)
            {
                baseUtcOffSet = baseUtcOffSet.Add(TimeSpan.FromHours(1));
            }
            return TimeZoneInfo.CreateCustomTimeZone("RegistredRecordTimeZone", baseUtcOffSet, string.Empty, string.Empty);
        }
    }
}

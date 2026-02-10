using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yinko.Domain.Entities
{
    internal class UserMissionProgress
    {
        public int UserId { get; set; }
        public int DailyMissionId { get; set; }
        public int CurrentValue { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow.Date;
    }
}

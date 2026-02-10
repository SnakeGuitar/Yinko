using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yinko.Domain.Entities
{
    public class DailyMission
    {
        public string Description { get; set; } = string.Empty;
        public int GoalValue { get; set; }
        public required MIssionType Type { get; set; }
        public int RewardInkos { get; set; }
    }
}

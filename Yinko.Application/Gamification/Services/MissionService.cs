using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yinko.Application.Gamification.Services
{
    public class MissionService
    {
        public async Task UpdateWordCountProgress(int userId, int wordsWritten)
        {
            var today = DateTime.UtcNow.Date;
            var progress = await _context.UserMissionProgress
                .FirstOrDefaultAsync(p => p.UserId == userId && p.Date == today);

            if (progress != null && !progress.IsCompleted)
            {
                progress.CurrentValue += wordsWritten;

                var mission = await _context.DailyMissions.FindAsync(progress.DailyMissionId);
                if (progress.CurrentValue >= mission.GoalValue)
                {
                    progress.IsCompleted = true;

                    // Otorgar recompensa al usuario
                    var user = await _context.Users.FindAsync(userId);
                    user.DepositInkos(mission.RewardInkos);
                }
                await _context.SaveChangesAsync();
            }
        }
    }
}

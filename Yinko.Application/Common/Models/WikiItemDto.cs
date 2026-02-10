using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yinko.Domain.Entities;

namespace Yinko.Application.Common.Models
{
    public class WikiItemDto
    {
        public string Term { get; set; }
        public string DisplayContent { get; set; }
        public bool IsSpoilerUnlocked { get; set; }

        public static WikiItemDto MapFromDomain(WikiItem item, int userProgressChapterId)
        {
            bool unlocked = item.UnlockChapterId.HasValue && userProgressChapterId >= item.UnlockChapterId;
            return new WikiItemDto
            {
                Term = item.Term,
                DisplayContent = unlocked ? $"{item.DefinitionSafe} {item.DefinitionSpoiler}" : item.DefinitionSafe,
                IsSpoilerUnlocked = unlocked
            };
        }
    }
}

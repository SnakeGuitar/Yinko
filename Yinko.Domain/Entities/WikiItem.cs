using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yinko.Domain.Common;
using Yinko.Domain.Enums;

namespace Yinko.Domain.Entities
{
    public class WikiItem : BaseEntity
    {
        public string Term { get; set; } = string.Empty;
        public WikiType Type { get; set; }

        public string DefinitionSafe { get; set; } = string.Empty;
        public string? DefinitionSpoiler { get; set; }
        public int? UnlockChapterId { get; set; }

        public int BookId { get; set; }
        public Book? Book { get; set; }
    }
}

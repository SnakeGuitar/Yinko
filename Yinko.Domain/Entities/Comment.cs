using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yinko.Domain.Common;

namespace Yinko.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; } = string.Empty;

        public bool IsModerated { get; set; } = false;
        public bool IsSpam { get; set; } = false;

        // Utility votes
        public int HelpfulVotesCount { get; set; } = 0;

        // Relationships
        public int UserId { get; set; }
        public User? User { get; set; }

        public int ChapterId { get; set; }
        public Chapter? Chapter { get; set; }

        public string? PharagraphId { get; set; }
    }
}

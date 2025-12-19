using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yinko.Domain.Common;

namespace Yinko.Domain.Entities
{
    public class UserTagPreference : BaseEntity
    {
        public int UserId { get; set; }
        public User? User { get; set; }

        public int TagId { get; set; }
        public Tag? Tag { get; set; }

        // -100 (strong dislike) to +100 (strong like), being 0 neutral
        public double Weight { get; set; }
    }
}

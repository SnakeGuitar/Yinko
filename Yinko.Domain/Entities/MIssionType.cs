using Yinko.Domain.Common;

namespace Yinko.Domain.Entities
{
    public class MIssionType : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
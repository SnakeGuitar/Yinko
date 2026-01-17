using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yinko.Application.Common.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string AvatarUrl { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;

        public int InkosBalance { get; set; }
        public int CurrentStreak { get; set; }
        public double CriticScore { get; set; }

        public List<BookDto> PublishedBooks { get; set; } = new();
    }
}

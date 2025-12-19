using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using Yinko.Domain.Common;
using Yinko.Domain.Common.Errors;
using Yinko.Domain.Common.Exceptions;

namespace Yinko.Domain.Entities
{
    public class User : BaseEntity
    {
        // Basic user information
        public int Id { get; set; }
        public string IdentityId { get; set; } = string.Empty; // It will come from ASP.NET auth table
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? AvatarUrl { get; set; } = string.Empty;
        public string? Bio { get; set; } = string.Empty;

        // Economy and gamification
        public int InkosBalance { get; set; } = 0;

        // Algorithmic core
        public double CriticScore { get; set; } = 0.0;
        public double PopularitySnapshot { get; set; }

        // Engagement metrics
        public int CurrentStreak { get; set; } = 0;
        public DateTime? LastLoginDate { get; set; }

        // Relationships
        public ICollection<Book> Books { get; set; } = new List<Book>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public ICollection<UserTagPreference> TagPreferences { get; set; } = new List<UserTagPreference>();

        public void UpdateUserProfile(string username, string bio, string avatarUrl)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new InvalidUserException(DomainErrors.User.UsernameRequired, "Username cannot be empty.");
            }

            if (bio.Length > 500)
            {
                throw new InvalidUserException(DomainErrors.User.BioTooLong, "Bio cannot exceed 500 characters.");
            }

            Username = username;
            Bio = bio;
            AvatarUrl = avatarUrl;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        public string IdentityId { get; set; } = string.Empty; // It will come from ASP.NET auth table
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string? AvatarUrl { get; private set; } = string.Empty;
        public string? Bio { get; private set; } = string.Empty;

        // Economy and gamification
        public int InkosBalance { get; private set; } = 0;

        // Algorithmic core
        public double CriticScore { get; set; } = 0.0;
        public double PopularitySnapshot { get; set; }

        // Engagement metrics
        public int CurrentStreak { get; private set; } = 0;
        public DateTime? LastLoginDate { get; private set; }

        // Relationships
        public ICollection<Book> Books { get; set; } = new List<Book>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<UserTagPreference> TagPreferences { get; set; } = new List<UserTagPreference>();

        public static User Create(string identityId, string username, string email)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new InvalidUserException(DomainErrors.User.UsernameRequired, "Username cannot be empty.");
            }
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            {
                throw new InvalidUserException(DomainErrors.User.EmailRequired, "A valid email address is required.");
            }
            return new User
            {
                IdentityId = identityId,
                Username = username,
                Email = email,
                InkosBalance = 50,
                CreatedAt = DateTime.UtcNow,
            };
        }

        public void UpdateProfile(string username, string bio, string avatarUrl)
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
            UpdatedAt = DateTime.UtcNow;
        }

        // Economy System
        // Inko is the virtual currency used in the platform
        public void DepositInkos(int amount)
        {
            if (amount <= 0) throw new InvalidInkosAmountException("INVALID_AMOUNT", "Deposit amount must be positive.");
            InkosBalance += amount;
        }
        public void WithdrawInkos(int amount)
        {
            if (amount <= 0) throw new InvalidInkosAmountException("INVALID_AMOUNT", "Amount must be positive.");
            if (InkosBalance < amount) throw new InvalidInkosAmountException("INSUFFICIENT_FUNDS", "Not enough Inkos.");

            InkosBalance -= amount;
        }

        // Engagement System
        public void RecordLogin()
        {
            var today = DateTime.UtcNow.Date;

            if (!LastLoginDate.HasValue)
            {
                CurrentStreak = 1;
            }
            else
            {
                var lastLogin = LastLoginDate.Value.Date;

                if (lastLogin == today.AddDays(-1))
                {
                    CurrentStreak++;
                }
                else if (lastLogin != today)
                {
                    CurrentStreak = 1;
                }
            }
            LastLoginDate = DateTime.UtcNow;
        }

        public void RegisterLogin()
        {
            var today = DateTime.UtcNow.Date;

            if (!LastLoginDate.HasValue)
            {
                CurrentStreak = 1;
            }
            else
            {
                var lastLogin = LastLoginDate.Value.Date;

                if (lastLogin == today.AddDays(-1))
                {
                    CurrentStreak++;
                }
                else if (lastLogin == today)
                {
                }
                else
                {
                    CurrentStreak = 1;
                }
            }

            LastLoginDate = DateTime.UtcNow;
        }
    }
}

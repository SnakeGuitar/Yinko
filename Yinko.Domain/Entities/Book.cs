using Yinko.Domain.Common;
using Yinko.Domain.Common.Errors;
using Yinko.Domain.Common.Exceptions;
using Yinko.Domain.Enums;

namespace Yinko.Domain.Entities
{
    public class Book : BaseEntity
    {
        // Basic book information
        public string Title { get; set; } = string.Empty;
        public string Synopsis { get; set; } = string.Empty;
        public string? CoverURL { get; set; }
        public BookStatus Status { get; set; } = BookStatus.Draft;

        // Algorithmic core
        public int ViewsCount { get; set; }
        public int LikesCount { get; set; }
        public double CompletionRate { get; set; }

        // Foreign keys
        public int AuthorId { get; set; }
        public User? Author { get; set; }

        // Relationships
        public ICollection<Chapter> Chapters { get; set; } = [];
        public ICollection<WikiItem> Wiki { get; set; } = [];

        public ICollection<Tag> Tags { get; set; } = [];

        public static Book Create(string title, string synopsis, int authorId)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new InvalidBookException(DomainErrors.Book.TitleRequired, "Book title cannot be empty.");
            }

            if (synopsis.Length < 10)
            {
                throw new InvalidBookException(DomainErrors.Book.SynopsisTooShort, "Book synopsis must be at least 10 characters long.");
            }

            if (synopsis.Length > 2000)
            {
                throw new InvalidBookException(DomainErrors.Book.SynopsisTooLong, "Book synopsis cannot exceed 2000 characters.");
            }

            return new Book
            {
                Title = title,
                Synopsis = synopsis,
                AuthorId = authorId,
                CreatedAt = DateTime.UtcNow,
            };
        }

        public void Update(string title, string synopsis)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new InvalidBookException(DomainErrors.Book.TitleRequired, "Book title cannot be empty.");
            }

            if (synopsis.Length < 10)
            {
                throw new InvalidBookException(DomainErrors.Book.SynopsisTooShort, "Book synopsis must be at least 10 characters long.");
            }

            if (synopsis.Length > 2000)
            {
                throw new InvalidBookException(DomainErrors.Book.SynopsisTooLong, "Book synopsis cannot exceed 2000 characters.");
            }

            Title = title;
            Synopsis = synopsis;
            UpdatedAt = DateTime.Now;
        }
    }
}

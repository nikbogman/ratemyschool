using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Core.ViewModels;
using Core.Interfaces;

namespace Core.Entities
{
    [Table("review")]
    public class ReviewEntity : BaseEntity
    {
        [Column("created_at")]
        public DateTime CreatedAt { get; private set; }

        [Column("content")]
        public string Content { get; private set; }

        [Column("rating")]
        public int Rating { get; private set; }

        [Column("reported")]
        public bool Reported { get; private set; }

        [Column("school_id")]
        public Guid SchoolId { get; private set; }

        [Column("user_id")]
        public Guid UserId { get; private set; }


        public int CompareTo(ReviewEntity? other)
        {
            if (other == null) return 0;
            return DateTime.Compare(this.CreatedAt, other.CreatedAt);
        }

        public ReviewEntity(DataRow row)
        {
            Id = Guid.Parse((string)row["id"]);
            Content = (string)row["content"];
            CreatedAt = (DateTime)row["created_at"];
            SchoolId = Guid.Parse((string)row["school_id"]);
            Reported = (bool)row["reported"];
            Rating = Convert.ToInt32(row["rating"]);
            UserId = Guid.Parse((string)row["user_id"]);
        }

        public ReviewEntity(ReviewViewModel viewModel)
        {
            CreatedAt = DateTime.Now;
            Content = viewModel.Content;
            Rating = viewModel.Rating;
            SchoolId = viewModel.SchoolId;
            UserId = viewModel.UserId;
        }

    }
}
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Models;

namespace Core.Entities
{
    [Table("review")]
    public class ReviewEntity : Entity
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

        public ReviewEntity(DataRow row): base(row)
        {
            Content = (string)row["content"];
            CreatedAt = (DateTime)row["created_at"];
            SchoolId = Guid.Parse((string)row["school_id"]);
            Reported = (bool)row["reported"];
            Rating = Convert.ToInt32(row["rating"]);
            UserId = Guid.Parse((string)row["user_id"]);
        }

        public ReviewEntity(ReviewModel model): base(model)
        {
            Content = model.Content;
            Rating = model.Rating;
            SchoolId = model.SchoolId;
            UserId = model.UserId;
            CreatedAt = DateTime.Now;
        }

    }
}
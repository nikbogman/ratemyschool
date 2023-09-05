using System.Data;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Models;

namespace Core.Entities
{
    [Table("report")]
    public class ReportEntity : Entity
    {
        [Column("reported_at")]
        public DateTime ReportedAt { get; private set; }

        [Column("reason")]
        public string Reason { get; private set; }

        [Column("review_id")]
        public Guid ReviewId { get; private set; }

        public ReportEntity(DataRow row) : base(row)
        {
            Reason = (string)row["reason"];
            ReportedAt = (DateTime)row["reported_at"];
            ReviewId = Guid.Parse((string)row["review_id"]);
        }

        public ReportEntity(ReportModel model) : base(model)
        {
            Reason = model.Reason;
            ReviewId = model.ReviewId;
        }
    }
}

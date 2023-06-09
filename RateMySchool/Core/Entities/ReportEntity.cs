﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Core.ViewModels;
using Core.Interfaces;

namespace Core.Entities
{
    [Table("report")]
    public class ReportEntity : BaseEntity
    {
        [Column("reported_at")]
        public DateTime ReportedAt { get; private set; }

        [Column("reason")]
        public string Reason { get; private set; }

        [Column("review_id")]
        public Guid ReviewId { get; private set; }

        public ReportEntity(DataRow row)
        {
            Id = Guid.Parse((string)row["id"]);
            Reason = (string)row["reason"];
            ReportedAt = (DateTime)row["reported_at"];
            ReviewId = Guid.Parse((string)row["review_id"]);
        }

        public ReportEntity(ReportViewModel viewModel)
        {
            Reason = viewModel.Reason;
            ReviewId = viewModel.ReviewId;
        }
    }
}

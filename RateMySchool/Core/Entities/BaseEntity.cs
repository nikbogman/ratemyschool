
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Core.Interfaces;
using Core.ViewModels;
using System.Data;

namespace Core.Entities
{
    public abstract class BaseEntity : IEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; protected set; }
        public void GenerateId() { Id = Guid.NewGuid(); }
        public void SetId(Guid id) { Id = id; }
    }
}

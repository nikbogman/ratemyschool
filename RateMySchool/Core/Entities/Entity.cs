using Core.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Core.Interfaces.Entities;

namespace Core.Entities
{
    public abstract class Entity : IEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; protected set; }

        public void GenerateId() { Id = Guid.NewGuid(); }
        public void SetId(Guid id) { Id = id; }

        public Entity(DataRow row)
        {
            Id = Guid.Parse((string)row["id"]);
        }
        public Entity(IModel model) { }

    }
}

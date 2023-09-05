using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using Core.Models;

namespace Core.Entities
{
    [Table("user")]
    public class UserEntity : Entity
    {
        [Column("password")]
        public string Password { get; private set; }

        [Column("email")]
        public string Email { get; private set; }

        [Column("birth_year")]
        public int BirthYear { get; private set; }

        public UserEntity(DataRow row): base(row)
        {
            Password = (string)row["password"];
            Email = (string)row["email"];
            BirthYear = (int)row["birth_year"];
        }

        public UserEntity(UserModel model): base(model)
        {
            Password = model.Password;
            Email = model.Email;
            BirthYear = model.BirthYear;
        }
    }
}

using Core.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using Core.Enums;

namespace Core.Entities
{
    [Table("user")]
    public class UserEntity : BaseEntity
    {
        [Column("password")]
        public string Password { get; private set; }

        [Column("email")]
        public string Email { get; private set; }

        [Column("birth_year")]
        public int BirthYear { get; private set; }

        [Column("role")]
        public UserRole Role { get; private set; }

        [Column("suspended_before")]
        public DateTime? SuspendedBefore { get; private set; }

        public UserEntity(DataRow row)
        {
            Id = Guid.Parse((string)row["id"]);
            Password = (string)row["password"];
            Email = (string)row["email"];
            BirthYear = (int)row["birth_year"];
            SuspendedBefore = row["suspended_before"] == DBNull.Value ? null : (DateTime)row["suspended_before"];
            Role = row.GetEnumValue<UserRole>("role");
        }

        public UserEntity(UserViewModel viewModel)
        {
            Password = viewModel.Password;
            Email = viewModel.Email;
            BirthYear = viewModel.BirthYear;
            Role = viewModel.Role;
            SuspendedBefore = viewModel.SuspendedBefore;
        }
    }
}

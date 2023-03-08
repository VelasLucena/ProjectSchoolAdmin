using InfoEnum;
using System.ComponentModel.DataAnnotations;

namespace ProfileModels
{
	public class UserModel
	{
		[Key]
		public int UserId { get; set; }

		[DataType(DataType.Text)]
		public string? Name { get; set; }
		public string? RegisterNumber { get; set; }

		[DataType(DataType.Password)]
		public string? Password { get; set; }
		public Office? Office { get; set; }
		public string? UserDetailsId { get; set; }
		public string? UserPermissionsId { get; set; }
		public DateTime? UpdateDate { get; set; }
		public DateTime? CreationDate { get; set; }
		public DateTime? DeletionDate { get; set; }
		public int? UpdateUserId { get; set; }
		public int? CreationUserId { get; set; }
	}
}

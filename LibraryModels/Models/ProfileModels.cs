using InfoEnum;
using System.ComponentModel.DataAnnotations;

namespace ProfileModels
{
	public class UserModel
	{
		[Key]
		public int? UserId { get; set; }

		[DataType(DataType.Text)]
		public string? Name { get; set; }
		public string? RegisterNumber { get; set; }

		[DataType(DataType.Password)]
		public string? Password { get; set; }
		public Office? Office { get; set; }
		public UserDetails? UserDetails { get; set; }
		public UserPermissions? UserPermissions { get; set; }
		public DateTime? UpdateDate { get; set; }
		public DateTime? CreationDate { get; set; }
		public DateTime? DeletionDate { get; set; }
		public int? UpdateUserId { get; set; }
		public int? CreationUserId { get; set; }
	}

	public class UserDetails
	{
		[Key]
		public int UserDetailsId { get; set; }

		[DataType(DataType.EmailAddress)]
		public string? Mail { get; set; }

		[DataType(DataType.PhoneNumber)]
		public string? Phone { get; set; }

		[DataType(DataType.PostalCode)]
		public int CEP { get; set; }
		public string? Address { get; set; }

		[DataType(DataType.Date)]
		public DateTime Birthdate { get; set; }

		[DataType(DataType.Date)]
		public DateTime ContractDate { get; set; }
		public string? RG { get; set; }
		public Gender Gender { get; set; }
		public decimal Wage { get; set; }
		public DateTime? UpdateDate { get; set; }
		public DateTime? CreationDate { get; set; }
		public DateTime? DeletionDate { get; set; }
		public int? UpdateUserId { get; set; }
		public int? CreationUserId { get; set; }
	}

	public class UserPermissions
	{
		[Key]
		public int UserPermissionsId { get; set; }
		public UserPermissionsType Type { get; set; }
		public string? Value { get; set; }
		public DateTime? UpdateDate { get; set; }
		public DateTime? CreationDate { get; set; }
		public DateTime? DeletionDate { get; set; }
		public int? UpdateUserId { get; set; }
		public int? CreationUserId { get; set; }
	}
}

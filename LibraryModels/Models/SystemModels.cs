using ServicesEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemModels
{
	public class Token
	{
		public int TokenId { get; set; }
		public string? Value { get; set; }
		public TokenType type { get; set; }
		public DateTime? ExpirationDate { get; set; }
		public DateTime? UpdateDate { get; set; }
		public DateTime? CreationDate { get; set; }
		public DateTime? DeletionDate { get; set; }
		public int? UpdateUserId { get; set; }
		public int? CreationUserId { get; set; }
	}
}

using Hastane.Core.Enums;

namespace NRM1_HastaneOtomasyon.Models.DTOs
{
	public class AddManagerDTO
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string Name { get; set; }
		public string Surname { get; set; }
		public string EmailAddress { get; set; }
		public Status Status { get; set; } = Status.Active;
		public decimal Salary { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;
	}
}

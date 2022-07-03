using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models;

	public class Association
	{
		[Key]
		public int AssociationID { get; set; }

		public int? UserID { get; set; }
		public int? WeddingID { get; set; }
		public User? User { get; set; }
		public Wedding? Wedding { get; set;}
		
	}



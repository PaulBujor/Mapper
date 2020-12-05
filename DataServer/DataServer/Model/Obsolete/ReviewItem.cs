namespace DataServer.Models
{
	public class ReviewItem 
	{
		public long id { get; set; }
		public int rating { get; set; }
		public string comment { get; set; }
		public User addedBy { get; set; }
	}
}
namespace Models
{
	public class Currency : BaseModel
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public byte IsActive { get; set; }
	}
}

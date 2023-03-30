namespace ComBookBackEnd.Models {
	public class Workplace {
		public Workplace(int sizeX, int sizeY, int row, int column, int id, string date, long bookingid, string username) {
			this.sizeX = sizeX;
			this.sizeY = sizeY;
			this.row = row;
			this.column = column;
			this.id = id;	
			this.date = date;
			this.bookingid = bookingid;
			this.username = username;
		}
		public int sizeX { get; set; }
		public int sizeY { get; set; }
		public int row { get; set; }
		public int column { get; set; }
		public int id { get; set; }
		public string date { get; set; }
		public long bookingid { get; set;}
		public string username { get; set; }
	}
}

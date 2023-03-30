namespace ComBookBackEnd.Models {
	public class Booking {
		public Booking(DateTime created, int roomid, int workplaceid, string date, long bookingid, string username) {
			this.created = created;
			this.roomid = roomid;
			this.workplaceid = workplaceid;
			this.date = date;
			this.bookingid = bookingid;
			this.username = username;
		}
		public DateTime created { get; set; }
		public int roomid { get; set; }
		public int workplaceid { get; set; }
		public string date { get; set; }
		public long bookingid { get; set; }
		public string username { get; set; }
	}
}


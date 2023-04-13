namespace ComBookBackEnd.Models {
	public class Room {
		public Room(int sizeX, int sizeY, string row, string column, int id, int floor, string name, List<Workplace> workplaces) {
			this.sizeX = sizeX;
			this.sizeY = sizeY;
			this.row = row;
			this.column = column;
			this.id = id;
			this.floor = floor;
			this.name = name;
			workplaceList = workplaces;
		}
		public int sizeX { get; set; }
		public int sizeY { get; set; }
		public string row { get; set; }
		public string column { get; set; }
		public int id { get; set; }
		public int floor { get; set; }
		public string name { get; set; }
		public List<Workplace> workplaceList { get; set; }
	}
}

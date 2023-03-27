namespace ComBookBackEnd.Models {
	public class Room {
		public Room(int sizeX, int sizeY, int row, int column, int id, int floor, List<Workplace> workplaces) {
			this.sizeX = sizeX;
			this.sizeY = sizeY;
			this.row = row;
			this.column = column;
			this.id = id;
			this.floor = floor;
			workplaceList = workplaces;
		}
		public int sizeX { get; set; }
		public int sizeY { get; set; }
		public int row { get; set; }
		public int column { get; set; }
		public int id { get; set; }
		public int floor { get; set; }
		public List<Workplace> workplaceList { get; set; }
	}
}

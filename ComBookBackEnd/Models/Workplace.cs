namespace ComBookBackEnd.Models {
	public class Workplace {
		public Workplace(int sizeX, int sizeY, int row, int column, int id) {
			this.sizeX = sizeX;
			this.sizeY = sizeY;
			this.row = row;
			this.column = column;
			this.id = id;	
		}
		public int sizeX { get; set; }
		public int sizeY { get; set; }
		public int row { get; set; }
		public int column { get; set; }
		public int id { get; set; }
	}
}

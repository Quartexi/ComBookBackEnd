using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Mvc;
using ComBookBackEnd.Models;
using static System.Net.Mime.MediaTypeNames;
using Mysqlx.Resultset;

namespace ComBookBackEnd.Database {

	public class ConnectDataBase {
		static MySqlConnection conn = new MySqlConnection();

		public static string connStr = @"SERVER=127.0.0.1;PORT=3307;DATABASE=combook;UID=root;PASSWORD=usbw;";

		public static void ConnectDatabase() {
			conn = new MySqlConnection(connStr);
			try {
				conn.Open();
			} catch (Exception ex) {
				Environment.Exit(404);
			}
			conn.Close();
		}

		public static List<Room> GetRooms(Room r) {
			ConnectDatabase();

			List<Room> RoomList = new List<Room>();

			conn.Open();
			string sql = "SELECT sizeX, sizeY, row, `column`, id, floor FROM room WHERE floor = ?floor";
			MySqlCommand cmd = new MySqlCommand(sql, conn);
			cmd.Parameters.AddWithValue("?floor", r.floor);

			var reader = cmd.ExecuteReader();

			if (reader.HasRows) {
				while (reader.Read()) {
					if (!reader.IsDBNull(0) && !reader.IsDBNull(1) && !reader.IsDBNull(2) && !reader.IsDBNull(3) && !reader.IsDBNull(4) && !reader.IsDBNull(5)) {
						int sizeX = reader.GetInt32(0);
						int sizeY = reader.GetInt32(1);
						int row = reader.GetInt32(2);
						int column = reader.GetInt32(3);
						int id = reader.GetInt32(4);
						int floor = reader.GetInt32(4);

						Room room = new Room(sizeX,sizeY, row, column, id, floor);
						RoomList.Add(room);
					}
				}
			}
			reader.Close();
			conn.Close();

			return RoomList;
		}

	}
}

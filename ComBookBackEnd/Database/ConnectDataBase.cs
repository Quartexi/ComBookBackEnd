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
using System.Runtime.CompilerServices;
using System.Text.Json.Nodes;

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

			List<Room> roomList = new List<Room>();

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
						int floor = reader.GetInt32(5);

						List<Workplace> workList = getWorkPlaceByRoomID(id, r.workplaceList[0].date);

						Room room = new Room(sizeX, sizeY, row, column, id, floor, workList);
						roomList.Add(room);
					}
				}
			}
			reader.Close();
			conn.Close();


			return roomList;
		}

		public static List<Workplace> getWorkPlaceByRoomID(int roomID, string date) {

			MySqlConnection conn = new MySqlConnection(connStr);

			conn.Open();

			List<Workplace> workList = new List<Workplace>();
			string sql = "SELECT sizeX, sizeY, `row`, `column`, id_workplace, COALESCE(bookingid, 0) AS bookingid, COALESCE(username, 0) AS username FROM workplace LEFT OUTER JOIN booking ON booking.workplaceid = workplace.id_workplace AND booking.date = ?date WHERE id_room = ?id";

			MySqlCommand cmd = new MySqlCommand(sql, conn);
			cmd.Parameters.AddWithValue("?id", roomID);
			cmd.Parameters.AddWithValue("?date", DateTime.Parse(date));
			MySqlDataReader readerWorkplace = cmd.ExecuteReader();

			if (readerWorkplace.HasRows) {
				while (readerWorkplace.Read()) {
					if (!readerWorkplace.IsDBNull(0) && !readerWorkplace.IsDBNull(1) && !readerWorkplace.IsDBNull(2) && !readerWorkplace.IsDBNull(3) && !readerWorkplace.IsDBNull(4) && !readerWorkplace.IsDBNull(5) && !readerWorkplace.IsDBNull(6)) {
						int sizeXworkplace = (int)readerWorkplace["sizeX"];
						int sizeYworkplace = (int)readerWorkplace["sizeY"];
						int rowworkplace = (int)readerWorkplace["row"];
						int columnworkplace = (int)readerWorkplace["column"];
						int idworkplace = (int)readerWorkplace["id_workplace"];
						long bookingid = (long)readerWorkplace["bookingid"];
						string username = readerWorkplace["username"].ToString();

						Workplace workplace = new Workplace(sizeXworkplace, sizeYworkplace, rowworkplace, columnworkplace, idworkplace, date, bookingid, username);
						workList.Add(workplace);
					}
				}
			}
			readerWorkplace.Close();
			conn.Close();
			return workList;
		}

		public static bool BookWorkPlace(Booking booking) {
			ConnectDatabase();

			conn.Open();
			string sql = "INSERT INTO `booking`(`created`, `roomid`, `workplaceid`, `date`, `username`) VALUES (?dateTime, (SELECT id_room FROM workplace WHERE id_workplace = ?workplaceId), ?workplaceId, ?bookingDate, ?username)";
			MySqlCommand cmd = new MySqlCommand(sql, conn);

			DateTime today = GetDateTime();

			cmd.Parameters.AddWithValue("?dateTime", today);
			cmd.Parameters.AddWithValue("?workplaceId", booking.workplaceid);
			cmd.Parameters.AddWithValue("?bookingDate", booking.date);
			cmd.Parameters.AddWithValue("?username", booking.username);

			cmd.ExecuteNonQuery();
			conn.Close();

			return true;
		}

		public static object getBookingInformation(Booking booking) {
			ConnectDatabase();

			conn.Open();
			string sql = "SELECT created, workplaceid, date, username FROM booking WHERE bookingid = ?bookingId";
			MySqlCommand cmd = new MySqlCommand(sql, conn);

			cmd.Parameters.AddWithValue("?bookingId", booking.bookingid);


			var reader = cmd.ExecuteReader();

			reader.Read();

			string created = reader.GetString(0);
			int workplaceid = reader.GetInt32(1);
			string date = reader.GetString(2);
			string username = reader.GetString(3);

			var payload = new { created = created, workplaceid = workplaceid, date = date, username = username };

			conn.Close();
			return payload;
		}

		public static DateTime GetDateTime() {
			DateTime today = DateTime.Now;
			return today;
		}

	}
}

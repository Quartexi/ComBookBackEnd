using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Mvc;


namespace ComBookBackEnd.Database {

	public class ConnectDataBase {
		static MySqlConnection conn = new MySqlConnection();

		public static string connStr = @"SERVER=127.0.0.1;PORT=3307;DATABASE=partygraph;UID=root;PASSWORD=usbw;";

		public static void ConnectDatabase() {
			conn = new MySqlConnection(connStr);
			try {
				conn.Open();
			} catch (Exception ex) {
				Environment.Exit(404);
			}
			conn.Close();
		}
	}
}

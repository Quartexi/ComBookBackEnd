using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using ComBookBackEnd.Models;
using ComBookBackEnd.Database;

namespace ComBookBackEnd.Controllers {

	[ApiController]
	[Route("api/[controller]/getRooms")]
	public class RoomController : ControllerBase {
		private readonly IConfiguration _configuration;
		public RoomController(IConfiguration configuration) {
			_configuration = configuration;
		}

		[HttpPost]
		public JsonResult Post(Room room) {
			ConnectDataBase.ConnectDatabase();
			return new JsonResult(ConnectDataBase.GetRooms(room));
		}
	}
}
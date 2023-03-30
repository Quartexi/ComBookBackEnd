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
	public class BookingController : ControllerBase {
		private readonly IConfiguration _configuration;
		public BookingController(IConfiguration configuration) {
			_configuration = configuration;
		}

		[Route("api/[controller]/bookWorkplace")]
		[HttpPost]
		public JsonResult Post(Booking booking) {
			return new JsonResult(ConnectDataBase.BookWorkPlace(booking));

		}

		[Route("api/[controller]/getBookingInformation")]
		[HttpPost]
		public JsonResult Post1(Booking booking) {
			return new JsonResult(ConnectDataBase.getBookingInformation(booking));

		}
	}
}
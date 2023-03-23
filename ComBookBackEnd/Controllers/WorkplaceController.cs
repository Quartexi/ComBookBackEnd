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

namespace ComBookBackEnd.Controllers {

	[ApiController]
	[Route("api/[controller]")]
	public class WorkplaceController : ControllerBase {
		private readonly IConfiguration _configuration;
		public WorkplaceController(IConfiguration configuration) {
			_configuration = configuration;
		}

		[HttpPost]
		public JsonResult Post(Workplace workplace) {
			bool x = true;
				return new JsonResult(x);

		}
	}
}
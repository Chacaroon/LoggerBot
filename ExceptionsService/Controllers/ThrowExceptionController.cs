using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThrowExceptionController : ControllerBase
    {
		[HttpGet]
		public void Get()
		{
			throw new Exception();
		}
    }
}
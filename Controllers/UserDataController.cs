using Microsoft.AspNetCore.Mvc;

namespace idp_elk.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UserDataController : ControllerBase
	{
		private readonly ILogger<UserDataController> _logger;

		public UserDataController(ILogger<UserDataController> logger)
		{
			_logger = logger;
		}

		[HttpPost]
		public IActionResult Post([FromBody] UserData userData)
		{
			_logger.LogInformation("Dados recebidos: {@UserData}", userData);
			return Ok("Dados logados com sucesso.");
		}

		public class UserData
		{
			public string Nome { get; set; }
			public string Email { get; set; }
			public string CPF { get; set; } // Dados sensíveis
			public string CartaoCredito { get; set; } // Dados sensíveis
		}

	}
}

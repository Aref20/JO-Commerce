using Microsoft.AspNetCore.Mvc;

namespace Common.Entities
{
    [ApiController]
    [Route("api/[Controller]")]
    [ApiVersion("1.0")]
    public class BaseController : ControllerBase
    {
    }
}

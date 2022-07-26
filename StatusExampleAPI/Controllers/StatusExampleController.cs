using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StatusExampleAPI.Controllers
{
    /// <summary>
    /// Status Example Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StatusExampleController : ControllerBase
    {
        /// <summary>
        /// Get the default HTTP status.
        /// </summary>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok();
        }

        /// <summary>
        /// Get the HTTP status provided as id
        /// </summary>
        /// <param name="id">id of the HTTP status</param>
        /// <response code="200">HTTP status Ok</response>
        /// <response code="201">HTTP status Created</response>
        /// <response code="400">HTTP status BadRequest</response>
        /// <response code="401">HTTP status Unauthorized</response>
        /// <response code="404">HTTP status NotFound</response>
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return id switch
            {
                200 => Ok(),
                201 => Created("https://www.example.com", "test"),
                400 => BadRequest(),
                401 => Unauthorized(),
                404 => NotFound(),
                _ => Ok(),
            };
        }
    }
}
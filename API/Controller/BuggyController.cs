


using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    public class BuggyController : BaseApiController
    {

        private readonly DataContext _context;

        public BuggyController(DataContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret text";
        }

        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var think = _context.Users.Find(-1);
            if (think == null) return NotFound();
            return think;
        }

        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            var think = _context.Users.Find(-1);
            var thiknToReturn = think.ToString();
            return thiknToReturn;
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("this is not a good request");
        }
    }
}
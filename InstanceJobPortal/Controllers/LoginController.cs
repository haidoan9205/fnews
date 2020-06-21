using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InstanceJobPortal.Controllers
{
    [Route("api/login")]
    public class LoginController : BaseController
    {
        private readonly ILoginLogic _loginLogic;

        public LoginController(ILoginLogic loginLogic)
        {
            _loginLogic = loginLogic;
        }

        [HttpPost]
        public IActionResult Login(string email, string password, string role)
        {
            string token = null;
            if (role.Equals("Applicant"))
            {
                token = _loginLogic.LoginApplicant(email, password);
            } 
            else if(role.Equals("Company"))
            {
                token = _loginLogic.LoginCompany(email, password);
            }
            else
            {
                return Unauthorized();
            }
            if(token == null)
            {
                return BadRequest("Email or password incorrect");
            }
            return Ok(token);
        }
    }
}
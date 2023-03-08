using InfoEnum;
using Microsoft.AspNetCore.Mvc;
using ProfileModels;
using ProjectApi.Code;
using System.Net;

namespace ProjectApi.Controllers
{
    [ApiController]
    [Route("[Action]")]
    public class PostController : ControllerBase
    {
        [HttpPost]
        [ActionName("CreateUser")]
        public async Task<IActionResult> CreateUser(UserModel createUser)
        {

            try
            {
                if(createUser.Office != Office.Student)
                {
                    bool validCpf = await Validation.ValidateCPF(createUser.RegisterNumber);

                    if (!validCpf)
                    {
                        return BadRequest();
                    }
                }

            }
            catch (Exception ex)
            {

            }

            return Ok();
        }
    }
}
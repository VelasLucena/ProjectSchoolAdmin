using InfoEnum;
using ProfileModels;
using ProjectApi.ValidationApi;
using ProjectApi.SystemDAO;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using ProjectApi.Mapper;

namespace ProjectApi.Controllers
{
    public class PostController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> CreateUser()
        {
            bool result;

            try
            {
                JsonRequest jsonRequest = new JsonRequest();
                using (var reader = new StreamReader(this.Request.Body,
                              encoding: Encoding.UTF8, detectEncodingFromByteOrderMarks: false))
                {
                    jsonRequest.json = await reader.ReadToEndAsync();
                }

                UserModel createUser = UserMapper.UserInputMapper(jsonRequest.json);

                bool modelValid = Validation.ValidUserCreation(createUser);

                if (ModelState.IsValid)
                {
                    result = SchemaProfileDAO.InsertUser(createUser);

                    if (result.Equals(false))
                        return BadRequest();
                }

            }
            catch (Exception ex)
            {

            }

            return Ok();
        }
    }
}
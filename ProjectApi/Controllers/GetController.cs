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
    public class GetController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetUserById()
        {
            UserModel result = new UserModel();

            try
            {
                JsonRequest jsonRequest = new JsonRequest();
                using (var reader = new StreamReader(this.Request.Body,
                              encoding: Encoding.UTF8, detectEncodingFromByteOrderMarks: false))
                {
                    jsonRequest.json = await reader.ReadToEndAsync();
                }

                UserModel user = UserMapper.UserGetInputMapper(jsonRequest.json);

                if (ModelState.IsValid)
                {
                    result = SchemaProfileDAO.GetUserById(user);

                    if (result == null)
                        return NotFound();
                }

            }
            catch (Exception ex)
            {

            }

            return Ok(Content(JsonConvert.SerializeObject(result)));
        }

        [HttpGet]
        public async Task<IActionResult> GetUserByRegisterNumberAndPassword()
        {
            UserModel result = new UserModel();

            try
            {
                JsonRequest jsonRequest = new JsonRequest();
                using (var reader = new StreamReader(this.Request.Body,
                              encoding: Encoding.UTF8, detectEncodingFromByteOrderMarks: false))
                {
                    jsonRequest.json = await reader.ReadToEndAsync();
                }

                UserModel user = UserMapper.UserGetInputMapper(jsonRequest.json);

                if (ModelState.IsValid)
                {
                    result = SchemaProfileDAO.GetUserByRegisterNumberAndPassword(user);

                    if (result == null)
                        return NotFound();
                }

            }
            catch (Exception ex)
            {

            }

            return Ok(Content(JsonConvert.SerializeObject(result)));
        }

        public async Task<IActionResult> GetUserByRegisterNumber()
        {
            UserModel result = new UserModel();

            try
            {
                JsonRequest jsonRequest = new JsonRequest();
                using (var reader = new StreamReader(this.Request.Body,
                              encoding: Encoding.UTF8, detectEncodingFromByteOrderMarks: false))
                {
                    jsonRequest.json = await reader.ReadToEndAsync();
                }

                UserModel user = UserMapper.UserGetInputMapper(jsonRequest.json);

                if (ModelState.IsValid)
                {
                    result = SchemaProfileDAO.GetUserByRegisterNumber(user);

                    if (result == null)
                        return NotFound();
                }

            }
            catch (Exception ex)
            {

            }

            return Ok(Content(JsonConvert.SerializeObject(result)));
        }
    }
}
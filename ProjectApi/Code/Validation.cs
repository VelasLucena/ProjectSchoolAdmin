using ProjectApi.SystemDAO;
using SystemModels;

namespace ProjectApi.Code
{
    public class Validation
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<bool> ValidateCPF(string cpf)
        {
            string resultGov = string.Empty;

            try
            {
                Token tokenGov = await TokenValidate();

                if (tokenGov == null)
                    throw new Exception();

                //resultGov = ExistCpfAsync(cpf);
            }
            catch (Exception ex)
            {

            }

            return true;
        }

        public static async Task<Token> TokenValidate()
        {
            Token tokenGov = SchemaSystemDAO.GetTokenGovByDate();

            if (tokenGov != null)
                return tokenGov;

            //var values = new Dictionary<string, string> { { "thing1", "hello" }, { "thing2", "world" } };

            //var content = new FormUrlEncodedContent(values);

            HttpResponseMessage response = await client.PostAsync("http://www.example.com/recepticle.aspx", null);

            Task<string>? responseString = response.Content.ReadAsStringAsync();

            return tokenGov;

        }

        public static async Task<string> ExistCpfAsync(long cpf)
        {
            var values = new Dictionary<string, string> { { "thing1", "hello" }, { "thing2", "world" } };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://www.example.com/recepticle.aspx", content);

            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;

        }
    }
}
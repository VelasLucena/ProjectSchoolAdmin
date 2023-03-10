using Newtonsoft.Json;
using ProfileModels;
using ProjectApi.Code;
using ServicesEnum;

namespace ProjectApi.Mapper
{
    public class UserMapper
    {
        public static UserModel UserPostInputMapper(string jsonInput)
        {
            UserModel createUser = JsonConvert.DeserializeObject<UserModel>(jsonInput);

            createUser.CreationDate = DateTime.Now;
            createUser.CreationUserId = Convert.ToInt32(AppSettingsJson.GetConfigurationApp(ConfigurationApp.DefaultUserId));
            createUser.UserDetails.CreationDate = createUser.CreationDate;
            createUser.UserDetails.CreationUserId = createUser.CreationUserId;
            createUser.UserPermissions.CreationDate = createUser.CreationDate;
            createUser.UserPermissions.CreationUserId = createUser.CreationUserId;

            return createUser;
        }

        public static UserModel UserGetInputMapper(string jsonInput)
        {
            UserModel user = JsonConvert.DeserializeObject<UserModel>(jsonInput);

            return user;
        }
    }
}

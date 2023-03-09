using ProfileModels;
using ProjectApi.SystemDAO;

namespace ProjectApi.ValidationApi
{
    public class Validation
    {
        public static bool ValidUserCreation(UserModel user)
        {
            UserModel isCreatedUser = SchemaProfileDAO.GetUserByRegisterNumber(user);

            if (isCreatedUser == null)
                return false;

            return true;
        }
    }
}

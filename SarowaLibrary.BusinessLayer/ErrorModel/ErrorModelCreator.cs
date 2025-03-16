using Microsoft.AspNetCore.Identity;

namespace SarowaLibrary.ToolsLayer.ErrorModel
{
    public static class ErrorModelCreator
    {
        public static Dictionary<string, string> ToErrorModel(this IdentityResult result)
        {
            if (result.Errors.Count() > 0)
            {
                string str = "";
                foreach (var key in result.Errors)
                {
                    str += key.Description + "\n";
                }
                return new Dictionary<string, string>() { { "ModelOnly", str } };
            }
            return new Dictionary<string, string>();
        }
        public static Dictionary<string, string> ToErrorModel(this FluentValidation.Results.ValidationResult result)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            foreach (var error in result.Errors)
            {
                if (!data.TryAdd(error.PropertyName, error.ErrorMessage))
                    data[error.PropertyName] = data[error.PropertyName] + "\n" + error.ErrorMessage;
            }
            return data;
        }
        public static Dictionary<string, string> ToErrorModel(this SignInResult result)
        {
            string str = "";
            if (!result.Succeeded)
                str += "Email or Password is invalid\n";
            if (result.IsLockedOut)
                str += "Your account is locked out\n";
            if (result.RequiresTwoFactor)
                str += "Your account is require two factor enterance\n";
            if (result.IsNotAllowed)
                str += "Your account is not allowed\n";
            if (string.IsNullOrWhiteSpace(str))
                return new Dictionary<string, string>();
            return new Dictionary<string, string>() { { "ModelOnly", str } }; ;
        }
    }
}

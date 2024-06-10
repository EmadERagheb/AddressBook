
namespace AddressBook.API.Errors
{
    public class APIResponse
    {
        public APIResponse(int stateCode, string message=null)
        {
            StateCode = stateCode;
            Message = message?? GetDefaultMessage(stateCode);
        }

        private string GetDefaultMessage(int stateCode)
        {
            return stateCode switch
            {
                400 => "The provided data does not meet the validation requirements",
                401 => "Invalid credentials provided. Please log in with valid credentials to access this resource",
                403=>"you don't have permission to execute this method",
                404 => "The page or resource you requested does not exist",
                405=>"method not allowed",
                500 => "We're experiencing technical difficulties. Our team is working to resolve the issue as quickly as possible.",
                _ => "please try again later"
            };
        }

        public int StateCode { get; set; }
        public string Message { get; set; }
    }
}

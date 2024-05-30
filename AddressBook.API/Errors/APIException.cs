namespace AddressBook.API.Errors
{
    public class APIException : APIResponse
    {
        public APIException(int stateCode, string message = null, string details=null) : base(stateCode, message)
        {
            Details = details;
        }

        public string Details { get; set; }


   

    }
}

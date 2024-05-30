namespace AddressBook.API.Errors
{
    public class APIValidationErrorResponse : APIResponse
    {
        public APIValidationErrorResponse(IEnumerable<string> errors) : base(400)
        {
            Errors = errors;
        }

        public IEnumerable<string> Errors { get; set; }
    }
}

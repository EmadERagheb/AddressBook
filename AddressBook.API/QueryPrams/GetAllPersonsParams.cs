namespace AddressBook.API.QueryPrams
{
    public class GetAllPersonsParams
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 6;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > 50 ? MaxPageSize : value;
        }
        public string? Sort { get; set; }

        public int? DepartmentId { get; set; }
        public int? JobId { get; set; }

        private string? fullName;

        public string? FullName {
            get=>fullName; 
            set=> fullName=value.Trim().ToLower();
        }

        private string? email;

        public string? Email
        {
            get => email;
            set => email = value.Trim();
        }

        private string? city;
        public string? City
        {
            get => city;
            set=>city=value.Trim().ToLower();
        }

        public DateTime? BirthDate { get; set; }


    }
}

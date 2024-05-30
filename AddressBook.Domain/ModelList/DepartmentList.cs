using AddressBook.Domain.Models;

namespace AddressBook.Domain.ModelList
{
    public static class DepartmentList
    {
        public static List<Department> Departments { get; set; } = new List<Department>()
        {
            new Department { Id = 1, Name = "General Medicine", JobId = 1, },
            new Department { Id = 2, Name = "Cardiology", JobId = 1 },
            new Department { Id = 3, Name = "Neurology", JobId = 1 },
            new Department { Id = 4, Name = "Surgery", JobId = 1 },
            new Department { Id = 5, Name = "Pediatrics", JobId = 1 },
            new Department { Id = 6, Name = "Software Engineering", JobId = 2 },
            new Department { Id = 7, Name = "Civil Engineering", JobId = 2 },
            new Department { Id = 8, Name = "Mechanical Engineering", JobId = 2 },
            new Department { Id = 9, Name = "Electrical Engineering", JobId = 2 },
            new Department { Id = 10, Name = "Chemical Engineering", JobId = 2 },
            new Department { Id = 11, Name = "Corporate Law", JobId = 3 },
            new Department { Id = 12, Name = "Criminal Law", JobId = 3 },
            new Department { Id = 13, Name = "Family Law", JobId = 3 },
            new Department { Id = 14, Name = "Intellectual Property Law", JobId = 3 },
            new Department { Id = 15, Name = "Tax Law", JobId = 3 },
            new Department { Id = 16, Name = "Mathematics Department", JobId = 4 },
            new Department { Id = 17, Name = "Science Department", JobId = 4 },
            new Department { Id = 18, Name = "History Department", JobId = 4 },
            new Department { Id = 19, Name = "English Department", JobId = 4 },
            new Department { Id = 20, Name = "Physical Education Department", JobId = 4 }
        };
    }


}

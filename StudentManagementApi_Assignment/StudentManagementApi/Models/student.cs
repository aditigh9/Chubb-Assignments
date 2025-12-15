namespace StudentManagementApi.Models
{
    public class Student
    {
        public int Id { get; set; }

        public required string Name { get; set; }
        public required string Class { get; set; }
        public required string Section { get; set; }
    }
}




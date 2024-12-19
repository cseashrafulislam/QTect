namespace QTect.Models
{
    public class Employee
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public DateTime JoinDate { get; set; }
        public int DepartmentID { get; set; }
        public string Status { get; set; } = "Active";
        public bool Deleted { get; set; } = true;
        public virtual Department Department { get; set; }
        public virtual ICollection<PerformanceReview> PerformanceReviews { get; set; }
        public virtual ICollection<Department> ManagedDepartments { get; set; }


    }
}

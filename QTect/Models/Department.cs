namespace QTect.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string DepartmentName { get; set; } 
        public decimal? Budget { get; set; }

        public int? ManagerID { get; set; }
        public virtual Employee Manager { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}

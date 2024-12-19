namespace QTect.Models
{
    public class PerformanceReview
    {
        public int ID { get; set; } 
        public int EmployeeID { get; set; } 
        public DateTime ReviewDate { get; set; } 
        public int ReviewScore { get; set; } 
        public string ReviewNotes { get; set; } 
        public virtual Employee Employee { get; set; }
    }
}

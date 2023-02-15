using System.ComponentModel.DataAnnotations;

namespace trackingapi.Model
{
    public class issue
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        public string issueName { get; set; }
        [Required] 
        public string issueDescription { get; set; }
        public Priority priority { get; set; }
        public IssueType issueType { get; set; }

        public DateTime created { get; set; }
        public DateTime? completed { get; set; }   

    }
    public enum Priority
    {
        Low, Medium, High
    }
    public enum IssueType { 
        Feature, Bug, Documentation
    }
}

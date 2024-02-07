
namespace JobApplicationAPI.Models
{

    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public DateTime PostedDate { get; set; }
        public List<Application> Applications { get; set; } = [];
    }

}

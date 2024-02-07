using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobApplicationAPI.Models
{
    public class Application
    {
        public int Id { get; set; }
        public string ApplicantName { get; set; } = string.Empty;
        public string ApplicantEmail { get; set; } = string.Empty;
        public string CoverLetter { get; set; } = string.Empty;

        [ValidateNever]
        public DateTime ApplicationDate { get; set; } = DateTime.Now;

        [ForeignKey("Job"), ValidateNever]
        public int JobId { get; set; }

        [ValidateNever]
        public Job Job { get; set; } = new Job();

    }
}

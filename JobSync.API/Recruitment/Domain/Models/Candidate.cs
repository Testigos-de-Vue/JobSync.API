using System.Runtime.InteropServices.JavaScript;
using JobSync.API.Authentication.Domain.Models;

namespace JobSync.API.Recruitment.Domain.Models;

public class Candidate
{
    public int Id { get; set; }
    public string CvUrl { get; set; }
    public Boolean IsActive { get; set; }
    public JSType.Date PostulationDate { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
    
    public int JobAreaId { get; set; }
    public JobArea JobArea { get; set; }
}
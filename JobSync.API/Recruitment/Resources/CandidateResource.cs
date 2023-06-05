using System.Runtime.InteropServices.JavaScript;
using JobSync.API.Authentication.Resources;

namespace JobSync.API.Recruitment.Resources;

public class CandidateResource
{
    public int Id { get; set; }
    public string CvUrl { get; set; }
    public Boolean IsActive { get; set; }
    public JSType.Date PostulationDate { get; set; }

    public UserResource UserArea { get; set; }
    public JobAreaResource JobArea { get; set; }
}
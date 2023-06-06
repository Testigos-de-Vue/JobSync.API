using JobSync.API.Authentication.Resources;

namespace JobSync.API.Recruitment.Resources;

public class CandidateProfileResource
{
    public int Id { get; set; }
    public string CvUrl { get; set; }
    public Boolean IsActive { get; set; }
    public DateTime PostulationDate { get; set; }

    public RecruitmentPhaseResource RecruitmentPhase { get; set; }
    public UserResource User { get; set; }
    public JobAreaResource JobArea { get; set; }
}
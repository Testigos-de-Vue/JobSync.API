namespace JobSync.API.Recruitment.Resources;

public class RecruitmentProcessResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime EndingDate { get; set; }
    public Boolean Status { get; set; }
}
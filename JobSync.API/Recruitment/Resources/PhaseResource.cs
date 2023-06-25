namespace JobSync.API.Recruitment.Resources;

public class PhaseResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public ProcessResource Process { get; set; }
}
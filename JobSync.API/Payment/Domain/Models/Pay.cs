namespace JobSync.API.Payment.Domain.Models;

public class Pay
{
    public int id { get; set; }
    public float mount { get; set; }
    public string currency { get; set; }
}
namespace JobSync.API.Payment.Domain.Models;

public class PaymentPlan
{
    public int id { get; set; }
    public string name { get; set; }
    public float initialPrice { get; set; }
    public int interest { get; set; }
    public int lapse { get; set; }
}
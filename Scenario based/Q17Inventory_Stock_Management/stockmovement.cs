using System;
namespace Q17{
public class StockMovement
{
    public int MovementId { get; set; }
    public string ProductCode { get; set; }
    public DateTime MovementDate { get; set; }
    public string MovementType { get; set; }
    public int Quantity { get; set; }
    public string Reason { get; set; }
}
}

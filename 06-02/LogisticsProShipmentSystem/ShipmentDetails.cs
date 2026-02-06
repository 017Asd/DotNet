using System;

public class ShipmentDetails : Shipment
{
    public bool ValidateShipmentCode()
    {
        if (ShipmentCode.Length != 7)
            return false;

        if (!ShipmentCode.StartsWith("GC#"))
            return false;

        for (int i = 3; i < ShipmentCode.Length; i++)
        {
            if (!char.IsDigit(ShipmentCode[i]))
                return false;
        }

        return true;
    }

    public double CalculateTotalCost()
    {
        double ratePerKg = 0;

        if (TransportMode == "Sea")
            ratePerKg = 15.00;
        else if (TransportMode == "Air")
            ratePerKg = 50.00;
        else if (TransportMode == "Land")
            ratePerKg = 25.00;

        double totalCost = (Weight * ratePerKg) + Math.Sqrt(StorageDays);
        return Math.Round(totalCost, 2);
    }
}

using System;


namespace GymStream
{
    public class MembershipService
    {
        public bool ValidateEnrollment(Membership member)
        {
            if (member.Tier != "Basic" &&
                member.Tier != "Premium" &&
                member.Tier != "Elite")
            {
                throw new InvalidTierException(
                    "Tier not recognized. Please choose an available membership plan."
                );
            }

            if (member.DurationInMonths <= 0)
            {
                throw new Exception("Duration must be at least one month.");
            }

            return true;
        }

        public double CalculateTotalBill(Membership member)
        {
            double total = member.DurationInMonths * member.BasePricePerMonth;
            double discount = 0;

            switch (member.Tier)
            {
                case "Basic":
                    discount = 0.02;
                    break;
                case "Premium":
                    discount = 0.07;
                    break;
                case "Elite":
                    discount = 0.12;
                    break;
            }

            return total - (total * discount);
        }
    }
}

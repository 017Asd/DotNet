using System;


namespace GymStream
{
    class Program
    {
        static void Main(string[] args)
        {
            Membership member = new Membership();
            MembershipService service = new MembershipService();

            try
            {
                Console.WriteLine("Enter membership tier (Basic/Premium/Elite):");
                member.Tier = Console.ReadLine();

                Console.WriteLine("Enter duration:");
                member.DurationInMonths = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter monthly price:");
                member.BasePricePerMonth = Convert.ToDouble(Console.ReadLine());

                if (service.ValidateEnrollment(member))
                {
                    Console.WriteLine("Enrollment Successful!");
                    double finalAmount = service.CalculateTotalBill(member);
                    Console.WriteLine($"Total amount after discount: {finalAmount:F2}");
                }
            }
            catch (InvalidTierException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

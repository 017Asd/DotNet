using System;

namespace Q1
{
    public class Program
    {
        public static void Main()
        {
            Manager manager = new Manager();

            while (true)
            {
                Console.WriteLine("\n----- CampusHire Menu -----");
                Console.WriteLine("1. Add Applicant");
                Console.WriteLine("2. Display All");
                Console.WriteLine("3. Search Applicant");
                Console.WriteLine("4. Update Applicant");
                Console.WriteLine("5. Delete Applicant");
                Console.WriteLine("6. Exit");

                Console.Write("Select option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddApplicant(manager);
                        break;

                    case "2":
                        manager.DisplayDetails();
                        break;

                    case "3":
                        Console.Write("Enter Applicant ID: ");
                        string searchId = Console.ReadLine();
                        var found = manager.SearchApplicant(searchId);

                        if (found != null)
                            Console.WriteLine($"{found.ApplicantId} {found.Name} {found.Year}");
                        else
                            Console.WriteLine("Applicant not found.");
                        break;

                    case "4":
                        UpdateApplicant(manager);
                        break;

                    case "5":
                        Console.Write("Enter Applicant ID to delete: ");
                        string deleteId = Console.ReadLine();
                        manager.DeleteRecord(deleteId);
                        Console.WriteLine("Record deleted if existed.");
                        break;

                    case "6":
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private static void AddApplicant(Manager manager)
        {
            try
            {
                Console.Write("Applicant ID: ");
                string id = Console.ReadLine();
                Validator.ValidateApplicantId(id);

                Console.Write("Name: ");
                string name = Console.ReadLine();
                Validator.ValidateName(name);

                Console.Write("Current Location: ");
                string current = Console.ReadLine();

                Console.Write("Preferred Location: ");
                string preferred = Console.ReadLine();

                Console.Write("Core Competency: ");
                string competency = Console.ReadLine();

                Console.Write("Passing Year: ");
                int year = int.Parse(Console.ReadLine());
                Validator.ValidatePassingYear(year);

                Applicant applicant = new Applicant(
                    id, name, current, preferred, competency, year);

                manager.AddApplication(applicant);

                Console.WriteLine("Applicant added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private static void UpdateApplicant(Manager manager)
        {
            try
            {
                Console.Write("Enter Applicant ID to update: ");
                string id = Console.ReadLine();

                var existing = manager.SearchApplicant(id);
                if (existing == null)
                {
                    Console.WriteLine("Applicant not found.");
                    return;
                }

                Console.Write("New Name: ");
                string name = Console.ReadLine();
                Validator.ValidateName(name);

                Console.Write("New Preferred Location: ");
                string preferred = Console.ReadLine();

                Console.Write("New Competency: ");
                string competency = Console.ReadLine();

                Console.Write("New Passing Year: ");
                int year = int.Parse(Console.ReadLine());
                Validator.ValidatePassingYear(year);

                Applicant updated = new Applicant(
                    id,
                    name,
                    existing.CurrentLocation,
                    preferred,
                    competency,
                    year
                );

                manager.UpdateDetails(id, updated);

                Console.WriteLine("Updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}

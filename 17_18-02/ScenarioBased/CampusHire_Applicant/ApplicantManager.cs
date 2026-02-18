using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Q1
{
    public class Manager
    {
        private List<Applicant> applicants;
        private readonly string filePath = "applicants.json";

        public Manager()
        {
            LoadFromFile();
        
        }
        public void AddApplication(Applicant applicant)
        {
            applicants.Add(applicant);
            SaveToFile();     
        }

        public void DisplayDetails()
        {
            foreach (var item in applicants)
            {
                Console.WriteLine($"{item.ApplicantId} {item.Name} {item.Year}");
            }
        }

        public Applicant? SearchApplicant(string id)
        {
            foreach (Applicant applicant in applicants)
            {
                if (applicant.ApplicantId == id)
                {
                    return applicant;
                }
            }
            return null;
        }

        public void UpdateDetails(string id, Applicant updatedApplicant)
        {
            foreach (Applicant applicant in applicants)
            {
                if (applicant.ApplicantId == id)
                {
                    applicant.Name = updatedApplicant.Name;
                    applicant.CurrentLocation = updatedApplicant.CurrentLocation;
                    applicant.PreferredLocation = updatedApplicant.PreferredLocation;
                    applicant.Competency = updatedApplicant.Competency;
                    applicant.Year = updatedApplicant.Year;

                    SaveToFile();  
                    return;
                }
            }
        }

        public void DeleteRecord(string id)
        {
            for (int i = 0; i < applicants.Count; i++)
            {
                if (applicants[i].ApplicantId == id)
                {
                    applicants.RemoveAt(i);
                    SaveToFile();   
                    return;
                }
            }
        }

        private void SaveToFile()
        {
            string json = JsonSerializer.Serialize(applicants, 
                new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(filePath, json);
        }

        private void LoadFromFile()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                applicants = JsonSerializer.Deserialize<List<Applicant>>(json)
                             ?? new List<Applicant>();
            }
            else
            {
                applicants = new List<Applicant>();
            }
        }
    }
}

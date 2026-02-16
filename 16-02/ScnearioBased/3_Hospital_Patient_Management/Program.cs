using System;

class Program
{
    static void Main()
    {
        var p1 = new PediatricPatient
        {
            PatientId = 1,
            Name = "Tom",
            DateOfBirth = new DateTime(2018, 5, 1),
            BloodType = BloodType.A,
            GuardianName = "John",
            Weight = 18
        };

        var p2 = new PediatricPatient
        {
            PatientId = 2,
            Name = "Lily",
            DateOfBirth = new DateTime(2016, 3, 10),
            BloodType = BloodType.B,
            GuardianName = "Anna",
            Weight = 22
        };

        var g1 = new GeriatricPatient
        {
            PatientId = 3,
            Name = "Mr. Smith",
            DateOfBirth = new DateTime(1950, 1, 1),
            BloodType = BloodType.O,
            MobilityScore = 5
        };

        var g2 = new GeriatricPatient
        {
            PatientId = 4,
            Name = "Mrs. Brown",
            DateOfBirth = new DateTime(1945, 7, 20),
            BloodType = BloodType.AB,
            MobilityScore = 7
        };

        var queue = new PriorityQueue<IPatient>();

        queue.Enqueue(g1, 1); // highest priority
        queue.Enqueue(p1, 2);
        queue.Enqueue(g2, 3);
        queue.Enqueue(p2, 4);

        Console.WriteLine("Next Patient: " + queue.Peek().Name);
        Console.WriteLine("Processing: " + queue.Dequeue().Name);

        var record = new MedicalRecord<IPatient>(p1);
        record.AddDiagnosis("Fever", DateTime.Now.AddDays(-2));
        record.AddTreatment("Paracetamol", DateTime.Now.AddDays(-1));

        Console.WriteLine("\nTreatment History:");
        foreach (var t in record.GetTreatmentHistory())
            Console.WriteLine($"{t.Key} - {t.Value}");

        var medicationSystem = new MedicationSystem<PediatricPatient>();

        medicationSystem.PrescribeMedication(
            p1,
            "Amoxicillin",
            patient => patient.Weight > 15  // weight-based validation
        );

        bool interaction = medicationSystem
            .CheckInteractions(p1, "Amoxicillin");

        Console.WriteLine("\nDrug Interaction Found: " + interaction);

        Console.ReadKey();
    }
}

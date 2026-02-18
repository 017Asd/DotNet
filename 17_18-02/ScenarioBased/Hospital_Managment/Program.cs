using System;
using System.Collections.Generic;

namespace Q4
{
    public class Program
    {
        public static void Main()
        {
            List<Doctor> doctors = new List<Doctor>();
            List<Patient> patients = new List<Patient>();
            List<Appointment> appointments = new List<Appointment>();
            Dictionary<int, MedicalRecord> medicalRecords = new Dictionary<int, MedicalRecord>();

            // Add Doctors
            doctors.Add(new Doctor(1, "Dr. Smith", true));
            doctors.Add(new Doctor(2, "Dr. John", true));

            // Add Patients
            patients.Add(new Patient(101, "Rahul"));
            patients.Add(new Patient(102, "Aman"));

            // Display Doctors
            Console.WriteLine("Doctors List:");
            foreach (var doc in doctors)
            {
                Console.WriteLine($"{doc.Id} - {doc.Name} - Available: {doc.IsAvailable}");
            }

            // Display Patients
            Console.WriteLine("\nPatients List:");
            foreach (var pat in patients)
            {
                Console.WriteLine($"{pat.Id} - {pat.Name}");
            }

            // STEP 2 - Book Appointment
            Console.WriteLine("\nBooking Appointment...");

            try
            {
                Doctor selectedDoctor = doctors[0];
                Patient selectedPatient = patients[0];

                Appointment appointment = new Appointment(
                    selectedDoctor,
                    selectedPatient,
                    DateTime.Now.AddDays(1)
                );

                appointments.Add(appointment);

                Console.WriteLine("Appointment booked successfully.");
            }
            catch (DoctorNotAvailableException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            // STEP 3 - Try Booking Again
            Console.WriteLine("\nTrying to book same doctor again...");

            try
            {
                Doctor sameDoctor = doctors[0];
                Patient anotherPatient = patients[1];

                Appointment secondAppointment = new Appointment(
                    sameDoctor,
                    anotherPatient,
                    DateTime.Now.AddDays(2)
                );

                appointments.Add(secondAppointment);

                Console.WriteLine("Second appointment booked.");
            }
            catch (DoctorNotAvailableException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            // STEP 4 - Create Medical Record
            Console.WriteLine("\nCreating Medical Record...");

            try
            {
                int recordId = 5001;

                if (medicalRecords.ContainsKey(recordId))
                    throw new DuplicateMedicalRecordException("Record already exists.");

                MedicalRecord record = new MedicalRecord(
                    recordId,
                    patients[0],
                    doctors[0],
                    "Fever and Cold"
                );

                medicalRecords.Add(recordId, record);

                Console.WriteLine("Medical record created successfully.");
            }
            catch (DuplicateMedicalRecordException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            // Try Duplicate Record
            Console.WriteLine("\nTrying to create duplicate record...");

            try
            {
                int recordId = 5001;

                if (medicalRecords.ContainsKey(recordId))
                    throw new DuplicateMedicalRecordException("Record already exists.");

                MedicalRecord duplicateRecord = new MedicalRecord(
                    recordId,
                    patients[1],
                    doctors[1],
                    "Headache"
                );

                medicalRecords.Add(recordId, duplicateRecord);
            }
            catch (DuplicateMedicalRecordException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}

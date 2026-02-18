using System;

namespace Q4
{
    public class Appointment
    {
        public Doctor Doctor { get; private set; }
        public Patient Patient { get; private set; }
        public DateTime AppointmentDate { get; private set; }

        public Appointment(Doctor doctor, Patient patient, DateTime appointmentDate)
        {
            if (!doctor.IsAvailable)
                throw new DoctorNotAvailableException("Doctor is not available.");

            Doctor = doctor;
            Patient = patient;
            AppointmentDate = appointmentDate;

            doctor.IsAvailable = false;
        }
    }
}

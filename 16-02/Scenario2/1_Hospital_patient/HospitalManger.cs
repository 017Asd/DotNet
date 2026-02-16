namespace Q1
{
    public class HospitalManager
    {
        private Dictionary<int, Patient> _patients = new Dictionary<int, Patient>();
        private Queue<Patient> _appointmentQueue = new Queue<Patient>();

        public void RegisterPatient(int id, string name, int age, string condition)
    {
        if (!_patients.ContainsKey(id))
        {
            Patient patient = new Patient(id, name, age, condition);
            _patients.Add(id, patient);
        }
        else
        {
            Console.WriteLine("Patient with this ID already exists.");
        }
    }

    public void ScheduleAppointment(int patientId)
    {
        if (_patients.ContainsKey(patientId))
        {
            _appointmentQueue.Enqueue(_patients[patientId]);
        }
        else
        {
            Console.WriteLine("Patient not found.");
        }
    }
    public Patient ProcessNextAppointment()
    {
        if (_appointmentQueue.Count > 0)
        {
            return _appointmentQueue.Dequeue();
        }

        Console.WriteLine("No appointments in queue.");
        return 0;
    }
     public List<Patient> FindPatientsByCondition(string condition)
    {
        return _patients.Values
                        .Where(p => p.Condition.Equals(condition, StringComparison.OrdinalIgnoreCase))
                        .ToList();
    }

    }
}
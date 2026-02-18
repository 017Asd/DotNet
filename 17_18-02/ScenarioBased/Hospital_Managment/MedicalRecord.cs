namespace Q4
{
    public class MedicalRecord
    {
        private Patient _patient;
        private Doctor _doctor;
        private string _diagnosis;

        public int RecordId { get; private set; }

        public MedicalRecord(int recordId, Patient patient, Doctor doctor, string diagnosis)
        {
            RecordId = recordId;
            _patient = patient;
            _doctor = doctor;
            _diagnosis = diagnosis;
        }

        public string GetDiagnosis()
        {
            return _diagnosis;
        }

        public double CalculateBill()
        {
            return 500; 
        }
    }
}

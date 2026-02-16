using System;
using System.Collections.Generic;
using System.Linq;

public interface IPatient
{
    int PatientId { get; }
    string Name { get; }
    DateTime DateOfBirth { get; }
    BloodType BloodType { get; }
}

public enum BloodType { A, B, AB, O }
public enum Condition { Stable, Critical, Recovering }

public class PriorityQueue<T> where T : IPatient
{
    private SortedDictionary<int, Queue<T>> _queues = new();
    
    public void Enqueue(T patient, int priority)
    {
        if (patient == null)
            throw new ArgumentNullException(nameof(patient));

        if (priority < 1 || priority > 5)
            throw new ArgumentException("Priority must be between 1 and 5.");

        if (!_queues.ContainsKey(priority))
            _queues[priority] = new Queue<T>();

        _queues[priority].Enqueue(patient);
    }
    
    public T Dequeue()
    {
        foreach (var pair in _queues.OrderBy(q => q.Key))
        {
            if (pair.Value.Count > 0)
                return pair.Value.Dequeue();
        }

        throw new InvalidOperationException("Queue is empty.");
    }
    
    public T Peek()
    {
        foreach (var pair in _queues.OrderBy(q => q.Key))
        {
            if (pair.Value.Count > 0)
                return pair.Value.Peek();
        }

        throw new InvalidOperationException("Queue is empty.");
    }
    
    public int GetCountByPriority(int priority)
    {
        if (_queues.ContainsKey(priority))
            return _queues[priority].Count;

        return 0;
    }
}


public class MedicalRecord<T> where T : IPatient
{
    private T _patient;
    private List<string> _diagnoses = new();
    private Dictionary<DateTime, string> _treatments = new();

    public MedicalRecord(T patient)
    {
        _patient = patient ?? throw new ArgumentNullException(nameof(patient));
    }
    
    public void AddDiagnosis(string diagnosis, DateTime date)
    {
        if (string.IsNullOrWhiteSpace(diagnosis))
            throw new ArgumentException("Diagnosis cannot be empty.");

        _diagnoses.Add($"{date:yyyy-MM-dd} - {diagnosis}");
    }
    
    public void AddTreatment(string treatment, DateTime date)
    {
        if (string.IsNullOrWhiteSpace(treatment))
            throw new ArgumentException("Treatment cannot be empty.");

        _treatments[date] = treatment;
    }
    
    public IEnumerable<KeyValuePair<DateTime, string>> GetTreatmentHistory()
    {
        return _treatments
            .OrderBy(t => t.Key);
    }
}


public class PediatricPatient : IPatient
{
    public int PatientId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public BloodType BloodType { get; set; }
    public string GuardianName { get; set; }
    public double Weight { get; set; }
}

public class GeriatricPatient : IPatient
{
    public int PatientId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public BloodType BloodType { get; set; }
    public List<string> ChronicConditions { get; } = new();
    public int MobilityScore { get; set; }
}


public class MedicationSystem<T> where T : IPatient
{
    private Dictionary<T, List<(string medication, DateTime time)>> _medications = new();
    
    public void PrescribeMedication(
        T patient,
        string medication,
        Func<T, bool> dosageValidator)
    {
        if (patient == null)
            throw new ArgumentNullException(nameof(patient));

        if (string.IsNullOrWhiteSpace(medication))
            throw new ArgumentException("Medication cannot be empty.");

        if (!dosageValidator(patient))
            throw new InvalidOperationException("Dosage validation failed.");

        if (!_medications.ContainsKey(patient))
            _medications[patient] = new List<(string, DateTime)>();

        _medications[patient].Add((medication, DateTime.Now));
    }
    
    public bool CheckInteractions(T patient, string newMedication)
    {
        if (!_medications.ContainsKey(patient))
            return false;

        var existing = _medications[patient]
            .Select(m => m.medication);

        return existing.Any(m => 
            m.Equals(newMedication, StringComparison.OrdinalIgnoreCase));
    }
}

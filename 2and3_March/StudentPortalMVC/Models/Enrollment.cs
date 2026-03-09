using System;
using System.Collections.Generic;

namespace StudentPortalMVC.Models;

public partial class Enrollment
{
    public int EnrollmentId { get; set; }

    public int StudentId { get; set; }

    public int CourseId { get; set; }

    // FIX: Change DateOnly → DateTime
    public DateOnly EnrollDate { get; set; }

    public string? PaymentStatus { get; set; }

    public decimal PaidAmount { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
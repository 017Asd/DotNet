using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var workflow = new LoanWorkflow();

        workflow.ChangeState(1, LoanState.Submitted);
        workflow.ChangeState(1, LoanState.InReview);
        workflow.ChangeState(1, LoanState.Approved);
        workflow.ChangeState(1, LoanState.Disbursed);

        Console.WriteLine("Workflow completed");
    }
}

enum LoanState
{
    Draft,
    Submitted,
    InReview,
    Approved,
    Rejected,
    Disbursed
}

class LoanWorkflow
{
    private readonly Dictionary<int, LoanState> current = new();
    private readonly Dictionary<int, List<LoanState>> history = new();

    public void ChangeState(int appId, LoanState next)
    {
        var curr = current.GetValueOrDefault(appId, LoanState.Draft);

        if (next == LoanState.Disbursed && curr != LoanState.Approved)
            throw new InvalidOperationException("Invalid transition");

        current[appId] = next;

        if (!history.ContainsKey(appId))
            history[appId] = new();

        history[appId].Add(next);
    }
}

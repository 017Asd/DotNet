namespace Q1
{
    public class Applicant
    {
        public string? ApplicantId{get;set;}
        public string? Name{get;set;}
        public string? CurrentLocation{get;set;}
        public string? PreferredLocation{get;set;}
        public string? Competency{get;set;}
        public int Year{get;set;}
        
        public Applicant()
        {
            
        }
        public Applicant(string applicantid,string name,string currentlocation,string preferredlocation,string competeny,int year)
        {
            this.ApplicantId=applicantid;
            this.Name=name;
            this.CurrentLocation=currentlocation;
            this.PreferredLocation=preferredlocation;
            this.Competency=competeny;
            this.Year=year;
        }
    }
}
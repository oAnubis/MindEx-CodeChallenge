namespace CodeChallenge.Models
{
    public class ReportingStructure
    {
        // The instructions explicitly stated fields, not properties so I made these fields with getters and setters.

        private int numberOfReports;

        private Employee employee;

        public int NumberOfReports
        {
            get { return numberOfReports; }
            set { numberOfReports = value; }
        }

        public Employee Employee
        {
            get { return employee; }
            set { employee = value; }
        }
    }
}
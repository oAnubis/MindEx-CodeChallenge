namespace CodeChallenge.Models
{
    public class ReportingStructure
    {
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
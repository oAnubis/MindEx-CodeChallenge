namespace CodeChallenge.Models
{
    public class Compensation
    {
        // I made these fields because the instructions explicitly stated field
        // plus the naming convention in the instructions matches the naming convention in C# for fields
        private Employee employee;

        private string salary;

        private string effectiveDate;

        private string compensationId;

        public Employee Employee
        {
            get { return employee; } 
            set { employee = value; }
        }

        public string Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public string EffectiveDate
        {
            get { return effectiveDate; }
            set { effectiveDate = value; }
        }

        public string CompensationId
        {
            get { return compensationId; }
            set { compensationId = value; }
        }
    }
}

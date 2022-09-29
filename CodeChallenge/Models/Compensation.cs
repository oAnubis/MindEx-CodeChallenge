namespace CodeChallenge.Models
{
    public class Compensation
    {
        // I made these fields because the instructions explicitly stated field
        // plus the naming convention in the instructions matches the naming convention in C# for fields
        private Employee employee;

        private decimal salary;

        private string effectiveDate;

        public Employee Employee
        {
            get { return employee; } 
            set { employee = value; }
        }

        public decimal Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public string EffectiveDate
        {
            get { return effectiveDate; }
            set { effectiveDate = value; }
        }
    }
}

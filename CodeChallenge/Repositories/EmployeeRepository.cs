using CodeChallenge.Data;
using CodeChallenge.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _employeeContext;

        private readonly ILogger<IEmployeeRepository> _logger;

        public EmployeeRepository(ILogger<IEmployeeRepository> logger, EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
            _logger = logger;
        }

        public Employee Add(Employee employee)
        {
            employee.EmployeeId = Guid.NewGuid().ToString();
            _employeeContext.Employees.Add(employee);
            return employee;
        }

        public Employee GetById(string id)
        {
            return _employeeContext.Employees.SingleOrDefault(e => e.EmployeeId == id);
        }

        public ReportingStructure RetrieveReportingStructure(string id)
        {
            #region Notes

            /*
             *  The instructions were clear the ReportingStructure is to be computed on the fly and not persisted.
             *  My theory is by instantiating a new ReportingStructure each time the Method is called from the controller, this satisfied this constraint.
             *
             *  Because this is essentially a tree structure for the data, I decided to utilize a Dictionary, which theoretically should allow quicker searches
             *      I recognize this thinking could be wrong, I look forward to going over this piece, and maybe have a discussion on the most optimized pattern
             *      to complete this method.
             */

            #endregion Notes

            // Instantiate a new ReportingStructure
            ReportingStructure report = new ReportingStructure();

            // Instantiate a new Dictionary to hold the employees in the database, where the Employee ID is extracted as the key
            Dictionary<string, Employee> employeeDictionary = _employeeContext.Employees.ToDictionary(e => e.EmployeeId);

            // Loops through the values in the dictionary, comparing the key(id) to the passed in id in the parameters, which correctly fills in the ReportingStructure
            foreach (var employee in employeeDictionary.Values)
            {
                if (!id.Equals(employee.EmployeeId))
                    report.employee = employeeDictionary[id];
            }

            // Counts the number of reports for the passed in employee id and assigns that value to the ReportingStructure numberOfReport property.
            report.numberOfReports = CountReports(report.employee);

            // returns the filled out report
            return report;
        }

        public int CountReports(Employee employee)
        {
            // Sets the target employee to equal the id passed

            // If the employee does not have any direct reports (which show as null) this will set the DirectReport list to an empty list.
            // I did this because it was printing that property as null, I figured this was a simple method to fix that issue.
            // Again, I am extremely interested in learning if this is the proper approach, or if there exists a better method to achieve the same results.
            if (employee.DirectReports == null)
            {
                employee.DirectReports = new List<Employee>();
                return 0;
            }

            // Sets the initial value of the report tracker variable to equal the number of reports for the currently targeted employee
            int reportCount = employee.DirectReports.Count;

            // Loops through each of the employees that are directly under the target employee in the management hierarchy.
            // the report count is aggregated for each direct report that has their own set of direct reports.
            foreach (Employee em in employee.DirectReports)
            {
                if (em != null)
                    reportCount += CountReports(em);
            }

            // returns the aggregated count for the total number of subordinates.
            return reportCount;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeContext.Employees;
        }

        public Task SaveAsync()
        {
            return _employeeContext.SaveChangesAsync();
        }

        public Employee Remove(Employee employee)
        {
            return _employeeContext.Remove(employee).Entity;
        }
    }
}
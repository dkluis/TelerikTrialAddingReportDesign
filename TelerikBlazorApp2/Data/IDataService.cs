using System.Collections.Generic;
using TelerikBlazorApp2.Models.Employee;
using TelerikBlazorApp2.Models.Sales;

namespace TelerikBlazorApp2.Data
{
    public interface IDataService
    {
        List<Employee> GetEmployees();
        IEnumerable<Sale> GetSales();
        List<Team> GetTeams();
    }
}

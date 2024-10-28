using HR.BLL.Interfaces;
using HR.DAL.Context;
using HR.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.BLL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HrDbContext _context;

        public EmployeeRepository(HrDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Employee> GetAll() => _context.Employees.ToList();

        public Employee GetById(int id)
        {
            var employee = _context.Employees.Local.Where(e => e.EmployeeId == id).FirstOrDefault();

            if (employee is null)
                employee = _context.Employees.Where(e => e.EmployeeId == id).FirstOrDefault();

            return employee;
        }
        public int Add(Employee employee)
        {
            _context.Add(employee);
            return _context.SaveChanges();
        }
        public int Update(Employee employee)
        {
            _context.Update(employee);
            return _context.SaveChanges();
        }
        public int Delete(int id)
        {
            var employee = _context.Employees.FirstOrDefault(C => C.EmployeeId == id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                return _context.SaveChanges();
            }
            return 0;
        }

        public IQueryable<Employee> GetEmployeesByName(string employeeName)
           => _context.Employees.Where(E=>E.Name.ToLower().Contains(employeeName.ToLower()));
    }
}



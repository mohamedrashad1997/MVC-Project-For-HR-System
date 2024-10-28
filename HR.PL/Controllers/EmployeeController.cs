using HR.BLL.Interfaces;
using HR.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HR.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IActionResult Index()
        {
            var employees = _employeeRepository.GetAll();
            return View(employees);
        }

        public IActionResult EmployeeInformation(string SearchValue)
        {
            IEnumerable<Employee> employees;
            if (string.IsNullOrEmpty(SearchValue))
                 employees = _employeeRepository.GetAll();
            else
               employees = _employeeRepository.GetEmployeesByName(SearchValue);

             return View(employees);

        }
        [HttpGet]
        public IActionResult CreateEmployee()
        {

            return View();
        }

        [HttpPost]
		public IActionResult CreateEmployee(Employee employee)
        {
            //if (ModelState.IsValid)
            //{

            //    _employeeRepository.Add(employee);
            //    TempData["Message"] = "Employee Added Successfully!";
            //    return RedirectToAction(nameof(EmployeeInformation));
            //}
            //return View(employee);

            try
            {
                _employeeRepository.Add(employee);
                TempData["Message"] = "Employee Added Successfully!";
                return RedirectToAction(nameof(EmployeeInformation));
            }
            catch (Exception ex)
            {
                //ModelState.AddModelError(string.Empty, "An error occurred while adding the employee.");
                // Log the exception if necessary
            }
        
            return View(employee);
        }

        public IActionResult UpdateEmployee(int? id)
        {
            if (id == null)
                return BadRequest();

            var employee = _employeeRepository.GetById(id.Value);
            if (employee is null)
                return NotFound();

            return View(employee);
        }

        [HttpPost]
        public IActionResult UpdateEmployee(Employee employee)
        {
            //if (ModelState.IsValid)
            //{
                try
                {
                    
                    _employeeRepository.Update(employee);
                    TempData["Message"] = "Employee Updated Successfully!";
                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            //}
            return View(employee);
        }

        [HttpPost]
        public IActionResult DeleteEmployee(int id)
        {
            if (id == 0)
                return RedirectToAction(nameof(EmployeeInformation));
            try
            {
                _employeeRepository.Delete(id);
            }
            catch (System.Exception ex)
            {
                //ModelState.AddModelError(string.Empty, ex.Message);
            }
            TempData["Message"] = "Employee Deleted Successfully!";
            return RedirectToAction(nameof(EmployeeInformation));
        }
    }
}

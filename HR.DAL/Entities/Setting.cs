using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DAL.Entities
{
    public class Setting
    {
        public int SettingId { get; set; }

        [Required(ErrorMessage = "Please select employees.")]
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

        [Required(ErrorMessage = "Overtime hours are required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Overtime hours must be a positive value.")]
        public decimal OvertimeHours { get; set; }

        [Required(ErrorMessage = "Discount hours are required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Discount hours must be a positive value.")]
        public decimal DiscountHours { get; set; }

        [Required(ErrorMessage = "Please select 2 vacation days.")]
        public string VacationDays { get; set; }
    }

    //public enum WeekDay
    //{
    //    Sunday,
    //    Monday,
    //    Tuesday,
    //    Wednesday,
    //    Thursday,
    //    Friday,
    //    Saturday
    //}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DAL.Entities
{
    public class Attendance
    {
        public int AttendanceId { get; set; }

        [Required(ErrorMessage = "Please select employee.")]
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

        [Required(ErrorMessage = "Date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Check-in time is required.")]
        [DataType(DataType.Time)]
        public TimeSpan CheckInTime { get; set; }

        [Required(ErrorMessage = "Check-out time is required.")]
        [DataType(DataType.Time)]
        public TimeSpan CheckOutTime { get; set; }
    }
}

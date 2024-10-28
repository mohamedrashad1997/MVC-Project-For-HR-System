using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DAL.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name must be less than 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Phone must be 11 digits")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; } // You might consider using an enum for fixed options

        [Required(ErrorMessage = "Hiring date is required")]
        [DataType(DataType.Date)]
        public DateTime HiringDate { get; set; }

        [Required(ErrorMessage = "Checkin Time is required")]
        [DataType(DataType.Time)]
        public TimeSpan CheckinTime { get; set; }

        [Required(ErrorMessage = "Checkout Time time is required")]
        [DataType(DataType.Time)]
        public TimeSpan CheckoutTime { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive value")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "National ID is required")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "National ID must be 14 digits")]
        public string NationalID { get; set; }

        [Required(ErrorMessage = "Nationality is required")]
        public string Nationality { get; set; }

        // Employment details

        [ForeignKey("Setting")]
        public int? SettingId{ get; set; }
        public Setting Settings { get; set; }

        [ForeignKey("Attendance")]
        public int? AttendanceId { get; set; }
        public Attendance Attendances { get; set; }

    }

    public enum Gender
    {
        Male,
        Female
    }
}

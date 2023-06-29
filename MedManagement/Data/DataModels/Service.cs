using System.ComponentModel.DataAnnotations;

namespace MedManagement.Data
{
    public class Service 
    {
    
        public int ServiceID { get; set; }
        [Required]
        public string ServiceName { get; set; }
        = string.Empty;
        [Required]
        public string ServiceDescription { get; set; }= string.Empty;
        [Required]
        public double ServicePrice { get; set; }
        //
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}

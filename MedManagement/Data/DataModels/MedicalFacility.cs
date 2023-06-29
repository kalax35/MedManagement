using System.ComponentModel.DataAnnotations;

namespace MedManagement.Data
{
    public class MedicalFacility
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string PostalCode { get; set; }
        //
        public IList<DoctorMedicalFacility> DoctorMedicalFacility { get; set; } = new List<DoctorMedicalFacility>();
        //
        public IList<Terms> Terms { get; set; } = new List<Terms>();
        //
        public IList<Doctor> Doctor { get; set; } = new List<Doctor>();
    }
}

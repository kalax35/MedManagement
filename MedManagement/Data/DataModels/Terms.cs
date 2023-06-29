using System.ComponentModel.DataAnnotations;

namespace MedManagement.Data
{
    public class Terms
    {
   
        public int TermsID { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime LastUpdatedOn { get; set;} = DateTime.Now;
        [Required]
        public bool IsBusy { get; set; }
        //MedicalFacility 1 - n Calendar
        public int MedicalFacilityId { get; set; }
        public MedicalFacility MedicalFacility { get; set; }
        //
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}

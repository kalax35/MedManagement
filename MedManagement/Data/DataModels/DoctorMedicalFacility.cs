using System.ComponentModel.DataAnnotations.Schema;

namespace MedManagement.Data
{
    public class DoctorMedicalFacility 
    {
        public int ID { get; set; }
        [ForeignKey(nameof(DoctorId))]

        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }
        [ForeignKey(nameof(MedicalFacilityId))]
        public MedicalFacility MedicalFacility { get; set; }
        public int MedicalFacilityId { get; set; }
    }
}

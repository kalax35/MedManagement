using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedManagement.Data
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        [Required]
        public string DoctorName { get; set; }
        [Required]
        public string DoctorSurname { get; set; }
        public string DoctorPhoto { get; set; }
        public string DoctorMedicalSpecialization { get; set; }
        public string DoctorAboutMe { get; set; }
        public string DoctorPhone { get; set; }
        //
        public IList<DoctorMedicalFacility> DoctorMedicalFacility { get; set; } = new List<DoctorMedicalFacility>();
        public IList<Terms> Terms { get; set; } = new List<Terms>();
        public IList<Service> Service { get; set; } = new List<Service>();
        public IList<Evaluation> Evaluation { get; set; } = new List<Evaluation>();
        public IList<DiseasesTreated> DiseasesTreated { get; set; } = new List<DiseasesTreated>();
    }
}

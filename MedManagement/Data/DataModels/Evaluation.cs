using System.ComponentModel.DataAnnotations;

namespace MedManagement.Data
{
    public class Evaluation
    {
        public int EvaluationID { get; set; }
        [Required]
        public int EvaluationValue { get; set; }
        public int EvaluationDesctyption { get; set; }
        //
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        //
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

    }
}

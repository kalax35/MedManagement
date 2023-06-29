

namespace MedManagement.Data
{
    public class Patient
    {
        public int PatientID { get; set; }
        public string PatientName { get; set;}
        public string PatientSurname { get; set; }
        public int PatientAge { get; set;}
        public PatientType PatientType { get; set; }

        public IList<Evaluation> Evaluations { get; set; } = new List<Evaluation>();

    }

    public enum PatientType
    {
        NFZ,
        Prywatny
    }
}

namespace MedManagement.Data
{
    public class DiseasesTreated
    {
        public int DiseasesTreatedID { get; set; }
        public string Name { get; set; }
        //
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}

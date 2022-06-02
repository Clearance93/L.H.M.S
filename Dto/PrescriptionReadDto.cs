namespace ClinicalApp.Dto
{
    public class PrescriptionReadDto
    {
        public int Id { get; set; }      
        public string PatientName { get; set; }     
        public decimal Amount { get; set; }
        public int Frequency { get; set; }
    }
}
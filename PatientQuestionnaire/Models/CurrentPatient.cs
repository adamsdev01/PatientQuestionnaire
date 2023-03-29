using System;
using System.Collections.Generic;

namespace PatientQuestionnaire.Models
{
    public partial class CurrentPatient
    {
        public long PatientId { get; set; }
        public string? PatientNumber { get; set; }
        public string? PatientFname { get; set; }
        public string? PatientLname { get; set; }
        public DateTime? PateintBirthDate { get; set; }
        public DateTime? HospitalAdmittedDate { get; set; }
        public DateTime? HospitalDischargeDate { get; set; }
        public string? HospitalLocation { get; set; }
        public string? HospitalWard { get; set; }
        public string? ActivePatient { get; set; }
    }
}

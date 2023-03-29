using System;
using System.Collections.Generic;

namespace PatientQuestionnaire.Models
{
    public partial class DrugQuestionnaire
    {
        public long QuestionnaireId { get; set; }
        public string? PatientNumber { get; set; }
        public string? ParticipatedInQuestionnaire { get; set; }
        public string? CompletedQuestionnaire { get; set; }
        public string? IsHappy { get; set; }
        public string? IsDrugUser { get; set; }
        public string? IsSuicidal { get; set; }
        public string? InterestedInTherapy { get; set; }
        public DateTime? InsertedDate { get; set; }

        public virtual DrugList? DrugList { get; set; }
    }
}

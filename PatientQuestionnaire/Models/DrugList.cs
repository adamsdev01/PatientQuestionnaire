using System;
using System.Collections.Generic;

namespace PatientQuestionnaire.Models
{
    public partial class DrugList
    {
        public long DrugListId { get; set; }
        public string? DrugName { get; set; }
        public long? FkQuestionnaireId { get; set; }

        public virtual DrugQuestionnaire? FkQuestionnaire { get; set; }
    }
}

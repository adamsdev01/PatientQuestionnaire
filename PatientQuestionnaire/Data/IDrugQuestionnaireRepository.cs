using PatientQuestionnaire.Models;

namespace PatientQuestionnaire.Data
{
    public interface IDrugQuestionnaireRepository
    {
        Task<IEnumerable<DrugQuestionnaire>> GetDrugQuestionnaires();
        Task<DrugQuestionnaire> GetQuestionnaire(long questionnaireId);
        Task AddQuestionnaire(DrugQuestionnaire questionnaire);
        Task UpdateQuestionnaire(DrugQuestionnaire questionnaire);
        Task DeleteQuestionnaire(long questionnaireId);
    }
}

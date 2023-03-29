using Microsoft.EntityFrameworkCore;
using PatientQuestionnaire.Models;
using System;

namespace PatientQuestionnaire.Data
{
    public class DrugQuestionnaireRepository : IDrugQuestionnaireRepository
    {
        private readonly PatientQuestionnaireDBContext _context;

        public  DrugQuestionnaireRepository(PatientQuestionnaireDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DrugQuestionnaire>> GetDrugQuestionnaires()
        {
            return await _context.DrugQuestionnaires
                .Include(q => q.DrugList)
                .ToListAsync();
        }

        public async Task<DrugQuestionnaire> GetQuestionnaire(long questionnaireId)
        {
            return await _context.DrugQuestionnaires.FindAsync(questionnaireId);
        }

        public async Task AddQuestionnaire(DrugQuestionnaire questionnaire)
        {
            questionnaire.InsertedDate = DateTime.Now;

            await _context.DrugQuestionnaires.AddAsync(questionnaire);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateQuestionnaire(DrugQuestionnaire questionnaire)
        {
            _context.Entry(questionnaire).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteQuestionnaire(long questionnaireId)
        {
            var questionnaire = await GetQuestionnaire(questionnaireId);
            _context.DrugQuestionnaires?.Remove(questionnaire);
            await _context.SaveChangesAsync();
        }    
    }
}

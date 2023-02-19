using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Herghys.Game.Quiz;

namespace Herghys.Global
{
    public class GlobalVariables
    {
        public static GlobalVariables Instance = new();
        public const string UNLOCKED_MATERI_KEY = "Materi_Unlocked";

        public List<AnsweredQuestion> answeredQuestions = new List<AnsweredQuestion>();

		public int TotalAnsweredQuesitons => answeredQuestions.Count;
		public int TotalCorrectAnswers()
		{
			if (answeredQuestions.Count == 0) return 0;
			return answeredQuestions.Where(q => q.IsCorrect).Count();
		}

		public void AddAsAnsweredQuestions(AnsweredQuestion answered)
        {
			if (answeredQuestions.Count == 0)
				AddToList(answered);

			var exist = answeredQuestions.Exists(q => q.Number == answered.Number);

			if (exist)
				OverrideExisting(answered);
			else
				AddToList(answered);
		}

		private void AddToList(AnsweredQuestion q)
		{
			answeredQuestions.Add(q);
		}

		private void OverrideExisting(AnsweredQuestion q)
		{
			var a = answeredQuestions.Where(qs => qs.Number == q.Number).SingleOrDefault();
			a = q;
		}
	}
}

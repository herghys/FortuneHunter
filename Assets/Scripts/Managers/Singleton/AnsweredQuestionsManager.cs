using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Herghys.Game.Quiz;
using UnityEngine;
using UnityEngine.Events;

namespace Herghys
{
    public class AnsweredQuestionsManager : GenericSingleton<AnsweredQuestionsManager>
    {
        [SerializeField] private List<AnsweredQuestion> answeredQuestions = new List<AnsweredQuestion>();
        [SerializeField] private List<AnsweredQuestion> test = new List<AnsweredQuestion>();

		public int TotalAnsweredQuesitons => answeredQuestions.Count;
		public int TotalCorrectAnswers()
		{
			if (answeredQuestions.Count == 0) return 0;
			return answeredQuestions.Where(q => q.IsCorrect).Count();
		}

		public void AddAsAnsweredQuestion(AnsweredQuestion answeredQuestion,UnityAction OnFailed)
        {
            test = answeredQuestions.Where(q => q.Number == answeredQuestion.Number).ToList();

            if (answeredQuestions.Count == 0)
                AddToList(answeredQuestion);

            var exist = answeredQuestions.Exists(q => q.Number == answeredQuestion.Number);
            Debug.Log($"Is Exist: {exist}");

            if(exist)
                OverrideExisting(answeredQuestion);
            else
                AddToList(answeredQuestion);
        }

        private void AddToList(AnsweredQuestion q)
        {
            answeredQuestions.Add(q);
        }

        private void OverrideExisting(AnsweredQuestion q)
        {
            var a= answeredQuestions.Where(qs => qs.Number == q.Number).SingleOrDefault();
            a = q;
        }
	}
}

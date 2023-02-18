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

        public void AddAsAnsweredQuestion(AnsweredQuestion answeredQuestion,UnityAction OnFailed)
        {
            if (answeredQuestions.Select(q => q.Number == answeredQuestion.Number).SingleOrDefault())
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

        }
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using Herghys.Game.Quiz;
using Herghys.Game.Quiz.Manager;
using UnityEngine;

namespace Herghys
{
    public class QuizUIController : GameUIBase
    {
        [SerializeField] QuestionTypes questionTypes;
        [SerializeField] QuestionController imageType;
        [SerializeField] QuestionController nonImageType;

		[SerializeField] QuizGameManager quizManager;

		[SerializeField] Question question;

		private void OnEnable()
		{
			CheckImageType();
		}

		private void CheckImageType()
		{
			if (questionTypes == QuestionTypes.Image)
			{
				imageType.gameObject.SetActive(true);
				nonImageType.gameObject.SetActive(false);
			}
			else
			{
				imageType.gameObject.SetActive(false);
				nonImageType.gameObject.SetActive(true);
			}
		}

		public void FillQuestionData(Question data)
        {
			question = data;
            questionTypes = data.Type;
			imageType.SetQuestionData(data);
			nonImageType.SetQuestionData(data);
			CheckImageType();
		}

		private void OnValidate()
		{
            //GetComponentsInChildren<AnswerData>(true, answerDatas);
            quizManager = FindObjectOfType<QuizGameManager>();
		}

		internal void AddSelectedAnswer(Answer answer)
		{
			quizManager.AddSelectedAnswer(answer);
		}
	}
}

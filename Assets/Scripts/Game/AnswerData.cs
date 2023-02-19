using System.Collections;
using System.Collections.Generic;
using Herghys.Game.Quiz;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Herghys
{
    public class AnswerData : MonoBehaviour
    {
        public Button button;
		public TextMeshProUGUI answerText;
        public Answer answer;

		public QuizUIController quizUIController;

		public bool IsCorrect;

		private void OnEnable()
		{
			button.onClick.AddListener(AddSelectedAnswer);
		}

		private void OnDisable()
		{
			button.onClick.RemoveListener(AddSelectedAnswer);
		}

		public void SetAnswer(Answer ans)
		{
			answer = ans;
			answerText.text = answer.Info;
			IsCorrect = answer.CorrectAnswer;
		}

		void AddSelectedAnswer()
		{
			quizUIController.AddSelectedAnswer(answer);
		}

		private void OnValidate()
		{
			button = GetComponentInChildren<Button>(true);
			answerText =  GetComponentInChildren<TextMeshProUGUI>(true);
			quizUIController = GetComponentInParent<QuizUIController>(true);
		}
	}
}

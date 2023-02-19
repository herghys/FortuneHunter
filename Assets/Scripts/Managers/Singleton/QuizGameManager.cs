using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Herghys.Game.Quiz;
using UnityEngine;
using UnityEngine.Events;

namespace Herghys
{
    public class QuizGameManager : MonoBehaviour
    {
        [SerializeField] AnsweredQuestionsManager answeredManager;

        [SerializeField] List<QuizDataSO> quizData;
        [SerializeField] int currentQuestionIndex;
        [SerializeField] int selectedAnswerIndex;
        [SerializeField] int totalQuestion;

        [Header("Question Current")]
        [SerializeField] Question currentQuestion;
        [SerializeField] Answer selectedAnswer;
        [SerializeField] AnsweredQuestion answeredQuestion;

        [SerializeField] QuizUIController quizUIControl;
        [SerializeField] GameManager gameManager;
        [SerializeField] GameManagerUI gameUI;

        public UnityEvent OnQuestionShown;

		private void Awake()
		{
			answeredManager = FindObjectOfType<AnsweredQuestionsManager>();
            totalQuestion = quizData.Count;

			quizUIControl = FindObjectOfType<QuizUIController>(true);

			UpdateQuestions();
		}

		private void OnEnable()
		{
			gameManager.ShowQuizQuestions += OnShowQuestion;
		}

		private void OnDisable()
		{
            gameManager.ShowQuizQuestions -= OnShowQuestion;	
		}

		[ContextMenu("Add As Answered Question")]
        public void AddAsAnsweredQuestionDummy()
        {
            if (answeredManager == null) return;

            if (currentQuestionIndex > quizData.Count)
                return;

            currentQuestion = new Question(quizData[currentQuestionIndex]);
            selectedAnswer = currentQuestion.Answers[selectedAnswerIndex];
            bool isCorrect = selectedAnswer.CorrectAnswer;
            answeredQuestion = new AnsweredQuestion(currentQuestion, selectedAnswer, isCorrect);
        }

		public void AddAsAnsweredQuestion()
		{
			if (answeredManager == null) return;

			if (currentQuestionIndex > quizData.Count)
				return;

			currentQuestion = new Question(quizData[currentQuestionIndex]);
			selectedAnswer = currentQuestion.Answers[selectedAnswerIndex];
			bool isCorrect = selectedAnswer.CorrectAnswer;
			answeredQuestion = new AnsweredQuestion(currentQuestion, selectedAnswer, isCorrect);
		}

        public void NextQuestion()
        {
            if (currentQuestionIndex < quizData.Count)
                currentQuestionIndex++;
        }

        public void UpdateQuestions()
        {
			currentQuestion = new Question(quizData[currentQuestionIndex]);
            quizUIControl.FillQuestionData(currentQuestion);
		}

		public void AddSelectedAnswer(Answer ans)
        {
            selectedAnswer = ans;
        }

		private void OnShowQuestion()
		{
            gameUI.OpenUI(quizUIControl as GameUIBase);
		}

		private void OnValidate()
		{
            gameManager = GetComponentInParent<GameManager>(true);
			answeredManager = FindObjectOfType<AnsweredQuestionsManager>();
			totalQuestion = quizData.Count - 1;
            quizUIControl = FindObjectOfType<QuizUIController>(true);
            gameUI = FindObjectOfType<GameManagerUI>(true);
		}
	}
}

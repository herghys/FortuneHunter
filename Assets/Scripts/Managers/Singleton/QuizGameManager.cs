using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Herghys.Game.Quiz;
using Herghys.Global;
using UnityEngine;
using UnityEngine.Events;

namespace Herghys
{
    public class QuizGameManager : MonoBehaviour
    {
		[Header("References")]
		[SerializeField] AnsweredQuestionsManager answeredManager;
		[SerializeField] QuizUIController quizUIControl;
		[SerializeField] GameManager gameManager;
		[SerializeField] GameManagerUI gameUI;

		[SerializeField] List<QuizDataSO> quizData;
        [SerializeField] int currentQuestionIndex;
        //[SerializeField] int selectedAnswerIndex;
        [SerializeField] int questionCount;

        [Header("Question Current")]
        [SerializeField] Question currentQuestion;
        [SerializeField] Answer selectedAnswer;
        [SerializeField] AnsweredQuestion answeredQuestion;

        public UnityEvent OnQuestionShown;
        public bool LastQuestion => currentQuestionIndex == questionCount;

		private void Awake()
		{
			answeredManager = FindObjectOfType<AnsweredQuestionsManager>();
            questionCount = quizData.Count;

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

		public void AddAsAnsweredQuestion()
		{
			if (currentQuestionIndex > quizData.Count)
				return;

			//currentQuestion = new Question(quizData[currentQuestionIndex]);
			//selectedAnswer = currentQuestion.Answers[selectedAnswerIndex];
			bool isCorrect = selectedAnswer.CorrectAnswer;
			answeredQuestion = new AnsweredQuestion(currentQuestion, selectedAnswer, isCorrect);

            if (answeredManager != null)
            {
                answeredManager.AddAsAnsweredQuestion(answeredQuestion, () => { });
            }

            GlobalVariables.Instance.AddAsAnsweredQuestions(answeredQuestion);

            Debug.Log($" Correct: {GlobalVariables.Instance.TotalCorrectAnswers()} / Total: {GlobalVariables.Instance.TotalAnsweredQuesitons}");

            gameManager.QuestionAnswered?.Invoke();
		}

        public void NextQuestion()
        {
            if (currentQuestionIndex < quizData.Count)
            {
                currentQuestionIndex++;
                UpdateQuestions();
            }
        }

        public void UpdateQuestions()
        {
            if (currentQuestionIndex >= questionCount)
            {
                StartCoroutine(IE_Endgame());
                return;
            }
			currentQuestion = new Question(quizData[currentQuestionIndex]);
            quizUIControl.FillQuestionData(currentQuestion);
		}

        IEnumerator IE_Endgame()
        {
            yield return new WaitForSeconds(1);
			gameUI.OpenEndGameUI();
		}

		public void AddSelectedAnswer(Answer ans)
        {
            selectedAnswer = ans;
            AddAsAnsweredQuestion();

		}

        public void UpdateSelectedAnswer(Answer ans)
        {
            currentQuestion.SelectedAnswer = ans;
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
			questionCount = quizData.Count - 1;
            quizUIControl = FindObjectOfType<QuizUIController>(true);
            gameUI = FindObjectOfType<GameManagerUI>(true);
		}
	}
}


/*[ContextMenu("Add As Answered Question")]
        public void AddAsAnsweredQuestionDummy()
        {
            if (answeredManager == null) return;

            if (currentQuestionIndex > quizData.Count)
                return;

            currentQuestion = new Question(quizData[currentQuestionIndex]);
            selectedAnswer = currentQuestion.Answers[selectedAnswerIndex];
            bool isCorrect = selectedAnswer.CorrectAnswer;
            answeredQuestion = new AnsweredQuestion(currentQuestion, selectedAnswer, isCorrect);
        }*/
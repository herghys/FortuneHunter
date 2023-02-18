using System.Collections;
using System.Collections.Generic;
using Herghys.Game.Quiz;
using UnityEngine;

namespace Herghys
{
    public class QuestionManager : MonoBehaviour
    {
        [SerializeField] AnsweredQuestionsManager answeredManager;

        [SerializeField] List<QuizDataSO> quizData;
        [SerializeField] int currentQuestionIndex;
        [SerializeField] int selectedAnswerIndex;

        [Header("Question Current")]
        [SerializeField] Question currentQuestion;
        [SerializeField] Answer selectedAnswer;
        [SerializeField] AnsweredQuestion answeredQuestion;

        [ContextMenu("Add As Answered Question")]
        public void AddAsAnsweredQuestion()
        {
            if (currentQuestionIndex > quizData.Count)
                return;

            currentQuestion = new Question(quizData[currentQuestionIndex]);
            selectedAnswer = currentQuestion.Answers[selectedAnswerIndex];
            bool isCorrect = selectedAnswer.CorrectAnswer;
            answeredQuestion = new AnsweredQuestion(currentQuestion, selectedAnswer, isCorrect);
            //answeredQuestion = new 
            
            //answeredQuestion = new AnsweredQuestion();

            //var selectedAnswer = 
            //var answeredQuestion = new AnsweredQuestion(quizData[selectedQuestion], );
            //AnsweredQuestionsManager.Instance.AddAsAnsweredQuestion(answeredQuestion, () => { });
        }

		private void OnValidate()
		{
			answeredManager = FindObjectOfType<AnsweredQuestionsManager>();
		}
	}
}

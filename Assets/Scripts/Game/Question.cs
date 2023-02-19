using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;


namespace Herghys.Game.Quiz
{
    [Serializable]
    public class Question
    {
        [SerializeField] QuestionTypes type = QuestionTypes.NonImage;
        [SerializeField] Sprite questionImage = null;
		[SerializeField] private int questionNo;
		[SerializeField] private int questionIndex;
		[SerializeField] private SubjectTypes materi;
		[TextArea(minLines: 1, maxLines: 10)]
		[SerializeField] private string questionInfo = string.Empty;
		[Range(1, 20)] 
		[SerializeField] private int timer = 5;
		[SerializeField] private Answer selectedAnswer = new();
		[SerializeField] private List<Answer> answers = new();

		[JsonProperty("questionData")]
		public QuestionTypes Type { get => type; set => type = value; }
		public Sprite Image { get => questionImage ; set => questionImage = value; }
		public int Number { get => questionNo; set => questionNo = value; }
		public int Index { get => questionIndex; set => questionIndex = value; }
		public SubjectTypes Materi { get => materi; set => materi = value; }
		public string Info { get => questionInfo; set => questionInfo = value; }
		public int Timer { get => timer; set => timer = value; }
		public Answer SelectedAnswer { get => selectedAnswer; set => selectedAnswer = value; }
		public List<Answer> Answers { get => answers; set => answers = value; }

		public Question() { }
		public Question(QuizDataSO so)
		{
			Number = so.Number;
			Index = so.Index;
			Materi = so.Materi;
			Timer = so.Timer;
			Info = so.Info;
			Answers = so.Answers;
		}


		public Answer GetCorrectAnswer() =>
            answers.Where(ans => ans.CorrectAnswer == true).FirstOrDefault();
	}

	[Serializable]
	public class QuestionData
	{
		[SerializeField] private int questionNo;
		[SerializeField] private int questionIndex;
		[SerializeField] private SubjectTypes materi;
		[TextArea(minLines: 1, maxLines: 10)]
		[SerializeField] private string questionInfo = string.Empty;
		[SerializeField] private bool isCorrect;
		[SerializeField] private Answer selectedAnswer = new();
		[SerializeField] private List<Answer> answers = new();

		[JsonProperty("questionData")]
		public int Number { get => questionNo; set => questionNo = value; }
		public int Index { get => questionIndex; set => questionIndex = value; }
		public SubjectTypes Materi { get => materi; set => materi = value; }
		public string Info { get => questionInfo; set => questionInfo = value; }
		public bool IsCorrect { get => isCorrect; set => isCorrect = value; }
		public Answer SelectedAnswer { get => selectedAnswer; set => selectedAnswer = value; }
		public List<Answer> Answers { get => answers; set => answers = value; }

		public QuestionData() { }
		public QuestionData(QuizDataSO so)
		{
			Number = so.Number;
			Index = so.Index;
			Materi = so.Materi;
			Info = so.Info;
			Answers = so.Answers;
		}
	}


	[Serializable]
    public class AnsweredQuestion
    {
		[SerializeField] private int questionNo;
		[SerializeField] private int questionIndex;
		[SerializeField] private SubjectTypes materi;
		[TextArea(minLines: 1, maxLines: 10)]
		[SerializeField] private string questionInfo = string.Empty;
        [SerializeField] private bool isCorrect;
        [SerializeField] private Answer selectedAnswer = new();
        [SerializeField] private List<Answer> answers = new();

        [JsonProperty("questionData")]
		public int Number {get => questionNo; set => questionNo = value; }
		public int Index {get => questionIndex; set => questionIndex = value; }
		public SubjectTypes Materi { get => materi; set => materi = value; }
		public string Info { get => questionInfo; set => questionInfo = value; }
        public bool IsCorrect { get => isCorrect; set => isCorrect = value; }
        public Answer SelectedAnswer { get => selectedAnswer; set => selectedAnswer = value; }
		public List<Answer> Answers {get => answers; set => answers = value; }

        public AnsweredQuestion() { }
        public AnsweredQuestion(QuizDataSO data, Answer selectedAnser,bool isAnsweredCorrectly)
        {
			Number = data.Number;
			Index = data.Index;
			Materi = data.Materi;
            Info = data.Info;
            IsCorrect = isAnsweredCorrectly;
            SelectedAnswer = selectedAnser;
            Answers = data.Answers;
        }

		public AnsweredQuestion(Question data, Answer selectedAnser, bool isAnsweredCorrectly)
		{
			Number = data.Number;
			Index = data.Index;
			Materi = data.Materi;
			Info = data.Info;
			IsCorrect = isAnsweredCorrectly;
			SelectedAnswer = selectedAnser;
			Answers = data.Answers;
		}
	}
}

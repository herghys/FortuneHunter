using System.Collections;
using System.Collections.Generic;
using Herghys.Game.Quiz;
using UnityEngine;
using UnityEngine.Serialization;

namespace Herghys
{
	[CreateAssetMenu(fileName = "1", menuName = "Quiz/Question Data")]
	public class QuizDataSO : ScriptableObject
	{
		[SerializeField] private int questionNo;
		[SerializeField] private int questionIndex;
		[SerializeField] private SubjectTypes materi;
		[TextArea(5, 20)]
		[SerializeField] private string questionInfo = string.Empty;
		[SerializeField] private QuestionTypes type = QuestionTypes.NonImage;
		[SerializeField] private Sprite questionImage = null;
		[Range(1, 20)] private int timer = 5;
		[SerializeField] List<Answer> answers= new List<Answer>();
		
		public int Number => questionNo;
		public int Index => questionIndex;
		public SubjectTypes Materi => materi;
		public string Info => questionInfo;
		public QuestionTypes Type => type;
		public Sprite Image => questionImage;
		public int Timer => timer;
		public List<Answer> Answers => answers;

#if UNITY_EDITOR
		private void OnValidate()
		{
			if (questionImage != null) type = QuestionTypes.Image;
			questionIndex = questionNo - 1;
			/*if (questionIndex != (int.Parse(this.name)))
			{
				try
				{
					int.TryParse(this.name, out int soName);
					questionIndex = soName;
				}
				catch (System.Exception)
				{

					throw;
				}
			}*/
		}
#endif
	}
}

using System.Collections;
using System.Collections.Generic;
using Herghys.Game.Quiz;
using UnityEngine;

namespace Herghys.Game.Quiz
{
	[CreateAssetMenu(fileName = "QuizDataList", menuName = "Quiz/List Data")]
	public class QuizDataListScriptable : ScriptableObject
	{
		public int level;
		public List<Question> questions = new();
	}
}
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Herghys.Game.Quiz;
using UnityEngine;

namespace Herghys.Game.Quiz.Manager
{
    public class QuizGameManagerOld : MonoBehaviour
    {
        [SerializeField] int currentLevel = 1;
        [SerializeField] List<QuizDataListScriptable> quizDataScriptables;
        [SerializeField] QuizData quizData;

		private void Awake()
		{
            quizDataScriptables = Resources.LoadAll<QuizDataListScriptable>("Quiz").OrderBy(x => x.level).ToList();
		}

		[ContextMenu("Next Level")]
        public void NextLevel()
        {
            var a = Resources.Load<QuizDataListScriptable>($"Quiz/{currentLevel}");
            //quizDataScriptable = a;

            quizData.Level = a.level;
            quizData.Questions = a.questions;

            Resources.UnloadAsset(a);
        }

        public void AddSelectedAnswer(Answer answer)
        {
            
        }
    }


}

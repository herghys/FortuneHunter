using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herghys.Game.Quiz
{
    [Serializable]
    public class Answer
    {
		[TextArea(minLines: 1, maxLines: 10)]
		[SerializeField] private string answerInfo;

        [SerializeField] private Sprite answerImage;
        [SerializeField] private bool isCorrectAnswer;

		#region Properties
		public string Info => answerInfo;
        public Sprite Image => answerImage;
        public bool CorrectAnswer => isCorrectAnswer;
		#endregion
	}
}

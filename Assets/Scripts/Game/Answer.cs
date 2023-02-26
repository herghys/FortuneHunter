using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
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
		[JsonProperty("Jawaban")]
		public string Info => answerInfo;
        [JsonIgnore]
        public Sprite Image => answerImage;
		[JsonProperty("Correct")]
		public bool CorrectAnswer => isCorrectAnswer;
		#endregion
	}
}

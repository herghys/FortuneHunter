using System;
using System.Collections;
using System.Collections.Generic;
using Herghys.Game.Quiz;
using UnityEngine;

namespace Herghys.Game.Quiz
{
	[Serializable]
    public class QuizData
    {
		[SerializeField] private int level;
		[SerializeField] private List<Question> questions = new();

		public int Level { get => level; set => level = value; }
		public List<Question> Questions {get => questions;set=> questions = value; }
	}
}

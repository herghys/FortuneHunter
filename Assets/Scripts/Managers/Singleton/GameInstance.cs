using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herghys
{
    public class GameInstance : GenericSingleton<GameInstance>
    {
		[SerializeField] AnsweredQuestionsManager answeredQuestionManager;

		public AnsweredQuestionsManager AnsweredQuestion { get => answeredQuestionManager; }

		public override void OnAwake()
		{
			base.OnAwake();
			answeredQuestionManager = GetComponentInChildren<AnsweredQuestionsManager>();	
			//answeredQuestionManager = SetupChildInstance(answeredQuestionManager);
		}

		T SetupChildInstance<T>(T type) where T : ChildInstanceManager
		{
			if (type is null) type = GetComponentInChildren<T>();
			type.GameInstanceRef = this;
			return type;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herghys
{
    public class GlobalEvents : SingletonClass<GlobalEvents>
    {
        public delegate void OnRunnerFinished();
        public delegate void OnRunnerStarted();
        public delegate void OnRunnerPaused();
    }

    public enum RunnerGameState
    {
        Intro, Playing, Paused, End
    }

	public enum QuestionTypes
	{
		NonImage, Image
	}

	public enum SubjectTypes
	{
		Ekskresi, Ginjal, Kulit, Paru, Hati
	}

	public enum MateriContentType
	{
		Head, Text, Space, Image, Subhead
	}
}
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
}
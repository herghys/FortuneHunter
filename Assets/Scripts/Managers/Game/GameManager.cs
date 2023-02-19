using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Herghys
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] GameManagerUI ui;

		public UnityAction<GameObject> MovePlayer;
		public UnityAction<Target> UpdateTargetReference;
        public UnityAction<Target> PlayerStopped;

		public UnityAction QuestionAnswered;

		public UnityAction ShowQuizQuestions;
		public UnityAction<GameState> UpdateState;

		public GameState state;

		
		public UnityEvent OnContinueAfterEnd;

		private void Awake()
		{
			state = GameState.Warmup;
		}

		private void OnValidate()
		{
			ui = GetComponent<GameManagerUI>();
		}

		private void OnEnable()
		{
			PlayerStopped += OnPlayerStopped;
			UpdateState += OnStateUpdated;
		}

		private void OnDisable()
		{
			PlayerStopped -= OnPlayerStopped;
			UpdateState -= OnStateUpdated;
		}

		public void StartGameplay()
			=> state = GameState.Play;

		private void OnStateUpdated(GameState arg0)
		{
			state = arg0;
		}

		private void OnPlayerStopped(Target target)
		{
			Debug.Log("Player Stopped");
			switch (state)
			{
				case GameState.Play:
					break;
				case GameState.ShowQuestion:
					ShowQuestion();
					break;
				case GameState.Pause:
					break;
				case GameState.End:
					ShowEnd();
					break;
				default:
					break;
			}
		}

		private void ShowQuestion()
		{
			ShowQuizQuestions?.Invoke();
		}

		private void ShowEnd()
		{
			Debug.Log("Show End");
		}

		public void ContinueAfterEnd()
		{
			ContinueAfterEnd();
		}

		public void ContinueNextLevel()
		{

		}
	}
}

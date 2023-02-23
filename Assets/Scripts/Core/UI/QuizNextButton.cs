using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Herghys
{
    public class QuizNextButton : MonoBehaviour
    {
        [SerializeField] Button button;
		[SerializeField] QuizGameManager quizManager;
		[SerializeField] GameManager manager;
		[SerializeField] GameManagerUI ui;
		[SerializeField] QuizUIController quizController;
		[SerializeField] bool CloseUIOnFinish;

		private void Awake()
		{
			manager = FindObjectOfType<GameManager>(true);
			button ??= GetComponent<Button>();
			quizManager ??= FindObjectOfType<QuizGameManager>(true);
			quizController ??= FindObjectOfType<QuizUIController>(true);
			ui ??= FindObjectOfType<GameManagerUI>(true);
		}

		private void OnEnable()
		{
			button.onClick.AddListener(Clicked);
		}

		private void OnDisable()
		{
			button.onClick.RemoveListener(Clicked);
		}

		public void Clicked()
		{
			if (quizManager.SelectedAnswer is null || string.IsNullOrEmpty(quizManager.SelectedAnswer.Info))
				return;

			quizManager.AddAsAnsweredQuestion();

			if (CloseUIOnFinish || quizManager.LastQuestion)
			{
				ui.CloseUI(quizController);
				manager.UpdateState?.Invoke(GameState.Play);
			}

			quizManager.NextQuestion();
		}

		private void OnValidate()
		{
			manager = FindObjectOfType<GameManager>(true);
			button = GetComponent<Button>();
			quizManager = FindObjectOfType<QuizGameManager>(true);
			quizController = FindObjectOfType<QuizUIController>(true);
			ui = FindObjectOfType<GameManagerUI>(true);
		}
	}
}

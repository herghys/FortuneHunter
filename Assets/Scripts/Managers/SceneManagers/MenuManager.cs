using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Herghys.Global;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Herghys
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] Button materiButton;
		[SerializeField] bool isFinished;
		[SerializeField] UIBase startUI;

		[SerializeField] List<UIBase> uiBases = new();

		private void Awake()
		{
			isFinished = GlobalVariables.Instance.IsFinished;
			if (materiButton != null)
			{
				if (isFinished)
					materiButton.gameObject.SetActive(true);
				else
					materiButton.gameObject.SetActive(false);
			}

			OpenUI(startUI);
		}

		public void OpenUI(UIBase uiBase)
		{
			uiBase.OpenWindow();
			foreach (var item in uiBases)
			{
				if (item != uiBase)
					item.CloseWindow();
			}
		}

		public void OpenMateri()
		{

		}

		public void OpenGame()
		{
			SceneManager.LoadScene("Game_Intro");
		}

		public void CloseGame()
		{
			Application.Quit();
		}

		private void OnValidate()
		{
			uiBases = FindObjectsOfType<UIBase>(true).ToList();
		}
	}
}

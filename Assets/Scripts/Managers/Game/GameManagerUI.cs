using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Herghys
{
    public class GameManagerUI : MonoBehaviour
    {
        [SerializeField] GameManager ui;

		[SerializeField] GameUIBase endGameUI;
		[SerializeField] GameUIBase startUI;

		[SerializeField]List<GameUIBase> gameUIs = new List<GameUIBase>();
		[SerializeField] GameUIBase activeUI;

		private void Awake()
		{
			CloseAllUI();
		}

		private void Start()
		{
			StartCoroutine(IE_Start());
		}

		IEnumerator IE_Start()
		{

			if (startUI != null)
			{
				yield return new WaitForSeconds(0.5f);
				OpenUI(startUI);
			}
		}

		public void OpenUI(GameUIBase ui)
		{
			activeUI = ui;
			activeUI.gameObject.SetActive(true);
			foreach (var item in gameUIs)
			{
				if (item != ui)
					item.gameObject.SetActive(false);
			}
		}

		public void CloseUI(GameUIBase ui)
		{
			activeUI.gameObject.SetActive(false);
			ui.gameObject.SetActive(false);
		}

		public void CloseUI()
		{
			activeUI.gameObject.SetActive(false);
		}

		public void CloseAllUI()
		{
			foreach (var item in gameUIs)
			{
				item.gameObject.SetActive(false);
			}
		}

		public void OpenEndGameUI()
		{
			OpenUI(endGameUI);
		}

		private void OnValidate()
		{
			ui = GetComponent<GameManager>();
			gameUIs = FindObjectsOfType<GameUIBase>(true).ToList() ;
		}
	}
}

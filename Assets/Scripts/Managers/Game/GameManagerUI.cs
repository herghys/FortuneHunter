using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Herghys
{
    public class GameManagerUI : MonoBehaviour
    {
        [SerializeField] GameManager ui;

		[SerializeField]List<GameUIBase> gameUIs = new List<GameUIBase>();
		[SerializeField] GameUIBase activeUI;

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

		private void OnValidate()
		{
			ui = GetComponent<GameManager>();
			gameUIs = FindObjectsOfType<GameUIBase>(true).ToList() ;
		}
	}
}

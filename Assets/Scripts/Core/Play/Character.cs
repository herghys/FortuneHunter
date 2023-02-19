using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herghys
{
    public class Character : MonoBehaviour, IClickable
    {
		[SerializeField] GameManager gameManager;

		private void Awake()
		{
			if (gameManager is null) gameManager = FindObjectOfType<GameManager>(true);
		}

		public void Click()
		{
			Debug.Log("Click");
			if (gameManager.state != GameState.Play) return;
			gameManager.MovePlayer?.Invoke(this.gameObject);
		}

		private void OnMouseDown()
		{
			Click();
		}
	}
}

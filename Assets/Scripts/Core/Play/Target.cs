using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herghys
{
    public class Target : MonoBehaviour, IClickable
    {
		[SerializeField] GameManager gameManager;

		private void Awake()
		{
			if (gameManager is null) gameManager = FindObjectOfType<GameManager>(true);
		}

		private void OnEnable()
		{
			gameManager.PlayerStopped += OnPlayerStopped;
		}

		private void OnDisable()
		{
			gameManager.PlayerStopped -= OnPlayerStopped;
		}

		public void Click()
		{
			Debug.Log("Click");
			if (gameManager.state != GameState.Play) return;
			gameManager.UpdateTargetReference?.Invoke(this);
			gameManager.MovePlayer?.Invoke(gameObject);
		}

		private void OnPlayerStopped(Target target)
		{
			if (target == this)
			gameObject.SetActive(false);
		}


		private void OnMouseDown()
		{
			Click();
		}

		private void OnValidate()
		{
			if (gameManager is null) gameManager = FindObjectOfType<GameManager>(true);
		}
	}
}

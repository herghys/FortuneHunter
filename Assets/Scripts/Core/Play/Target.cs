using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herghys
{
    public class Target : MonoBehaviour, IClickable
    {
		[SerializeField] GameManager gameManager;
		[SerializeField] Collider col;
		[SerializeField] List<ParticleSystem> particlesToDisable = new();

		[SerializeField] bool isSelected;

		private void Awake()
		{
			if (gameManager is null) gameManager = FindObjectOfType<GameManager>(true);
		}

		private void OnEnable()
		{
			gameManager.PlayerStopped += OnPlayerStopped;
			gameManager.QuestionAnswered += OnQuestionAnswered;
		}

		private void OnDisable()
		{
			gameManager.PlayerStopped -= OnPlayerStopped;
			gameManager.QuestionAnswered -= OnQuestionAnswered;
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
			{
				particlesToDisable.ForEach (x => x.gameObject.SetActive(false));
				col.enabled = false;
				isSelected = true;
			}	
			//gameObject.SetActive(false);
		}

		private void OnQuestionAnswered()
		{
			if (isSelected && gameObject.activeSelf)
				gameObject.SetActive(false);
		}


		private void OnMouseDown()
		{
			Click();
		}

		private void OnValidate()
		{
			if (gameManager is null) gameManager = FindObjectOfType<GameManager>(true);
			GetComponentsInChildren(true, particlesToDisable);
			col = GetComponent<Collider>();
		}
	}
}

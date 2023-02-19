using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herghys
{
    public class StopPlace : MonoBehaviour
    {
		public GameManager manager;
		public GameState state;

		private void Awake()
		{
			if (manager == null) manager = FindObjectOfType<GameManager>();
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				manager.UpdateState?.Invoke(state);
				var player = other.GetComponent<PlayerController>();
				player.StopMoving();
			}
		}

		private void OnCollisionEnter(Collision collision)
		{
			if (collision.collider.CompareTag("Player"))
			{
				manager.UpdateState?.Invoke(state);
				var player = collision.collider.GetComponent<PlayerController>();
				player.StopMoving();
			}
		}

		private void OnValidate()
		{
			if (manager == null) manager = FindObjectOfType<GameManager>();
		}
	}
}

public enum GameState
{
	Warmup, Play, ShowQuestion, Pause, End
}
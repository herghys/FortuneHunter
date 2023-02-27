using UnityEngine;
using UnityEngine.Playables;

namespace Herghys
{
    public class StopPlace : MonoBehaviour
    {
		public GameManager manager;
		public GameState state;
		public PlayableDirector director;
		public PlayableAsset clip;
		public bool triggerCutscene;

		private void Awake()
		{
			if (manager == null) manager = FindObjectOfType<GameManager>();
			if (director == null) director = FindObjectOfType<PlayableDirector>();
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				var player = other.GetComponent<PlayerController>();
				player.StopMoving();
				if (triggerCutscene)
					PlayCutscene();
				else
					manager.UpdateState?.Invoke(state);
			}
		}

		private void OnCollisionEnter(Collision collision)
		{
			if (collision.collider.CompareTag("Player"))
			{
				var player = collision.collider.GetComponent<PlayerController>();
				player.StopMoving();
				if (triggerCutscene) 
					PlayCutscene();
				else
					manager.UpdateState?.Invoke(state);
			}
		}

		private void OnValidate()
		{
			if (manager == null) manager = FindObjectOfType<GameManager>();
		}

		public void PlayCutscene()
		{
			director.playableAsset= clip;
			director.Play();
		}

		public void UpdateState()
		{
			Debug.Log("Update State");
			manager.UpdateState?.Invoke(state);
			director.Stop();
		}
	}
}

public enum GameState
{
	Warmup, Play, ShowQuestion, Pause, End
}
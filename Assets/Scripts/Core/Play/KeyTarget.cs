using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herghys
{
    public class KeyTarget : MonoBehaviour
    {
		[SerializeField] KeyManager manager;
		[SerializeField] Collider col;
		[SerializeField] List<ParticleSystem> particlesToDisable = new();

		[SerializeField] bool isSelected;

		private void OnCollisionEnter(Collision collision)
		{
			if (collision.collider.CompareTag("Player"))
			{
				manager.UpdateKey();
				var player = collision.collider.GetComponent<PlayerController>();
				player.StopMoving();
				gameObject.SetActive(false);
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				manager.UpdateKey();
				var player = other.GetComponent<PlayerController>();
				player.StopMoving();
				gameObject.SetActive(false);
			}
		}
	}
}

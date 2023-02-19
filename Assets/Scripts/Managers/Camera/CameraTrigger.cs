using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace Herghys
{
    public class CameraTrigger : MonoBehaviour
    {
        [SerializeField] CinemachineVirtualCamera _cam;

		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				CameraSwitcher.SwitchCamera(_cam);
			}
		}

		private void OnCollisionEnter(Collision collision)
		{
			if (collision.collider.gameObject.CompareTag("Player"))
			{
				CameraSwitcher.SwitchCamera(_cam);
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace Herghys
{
    public class CameraRegister : MonoBehaviour
    {
		[SerializeField] CinemachineVirtualCamera cam;
		private void OnEnable()
		{
			CameraSwitcher.Register(cam);
		}

		private void OnDisable()
		{
			CameraSwitcher.Unregister(cam);
		}

		private void OnValidate()
		{
			cam = GetComponent<CinemachineVirtualCamera>();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace Herghys
{
    public static class CameraSwitcher
    {
        static List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();

        public static CinemachineVirtualCamera ActiveCamera = null;

        public static bool IsActiveCamera(CinemachineVirtualCamera camera)
        => camera == ActiveCamera;

        public static void SwitchCamera(CinemachineVirtualCamera camera)
        {
            camera.Priority = 10;
            ActiveCamera= camera;
            foreach (var c in cameras)
            {
                if (c != camera && c.Priority != 0)
                {
                    c.Priority = 0;
                }
            }
        }

        public static void Register(CinemachineVirtualCamera camera)
            => cameras.Add(camera);
        
		public static void Unregister(CinemachineVirtualCamera camera)
            => cameras.Remove(camera);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Herghys
{
    [RequireComponent(typeof(Canvas), typeof(GraphicRaycaster))]
    public class UIBase : MonoBehaviour
    {
        [SerializeField] protected Canvas canvas;
        public virtual void OpenWindow()
        {
            gameObject.SetActive(true);
            canvas.enabled = true;
        }

        public virtual void CloseWindow() 
        {
            gameObject.SetActive(false);
            canvas.enabled= false;
        }

        public virtual void OpenChild() { }
        public virtual void CloseChild() { }

		private void OnValidate()
		{
			canvas = GetComponent<Canvas>();
		}
	}
}

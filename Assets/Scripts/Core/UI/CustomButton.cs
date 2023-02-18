using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Herghys
{
    [RequireComponent(typeof(Button))]
    public class CustomButton : MonoBehaviour
    {
        [SerializeField] protected Button button;

		private void OnEnable()
		{
			button.onClick.AddListener(OnButtonClicked);
		}

		private void OnDisable()
		{
			button.onClick.RemoveListener(OnButtonClicked);
		}

		public virtual void OnButtonClicked() { }

		protected virtual void OnValidate()
		{
			button = GetComponent<Button>();
		}
	}
}
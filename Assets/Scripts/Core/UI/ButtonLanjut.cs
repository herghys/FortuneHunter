using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Herghys
{
    public class ButtonLanjut : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler

    {
        [SerializeField] private TextMeshProUGUI text;

        [SerializeField] private ColorBlock colors;

		private void OnValidate()
		{
			text = GetComponentInChildren<TextMeshProUGUI>(true);
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			text.color = colors.pressedColor;
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			text.color = colors.highlightedColor;
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			text.color = colors.normalColor;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			throw new System.NotImplementedException();
		}
	}
}

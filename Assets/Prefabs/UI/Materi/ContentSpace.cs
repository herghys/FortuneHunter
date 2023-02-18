using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herghys
{
    public class ContentSpace : ContentHolder
    {
        [SerializeField] RectTransform rect;

		public override void SetContent(float height)
		{
			rect.sizeDelta = new Vector2(rect.sizeDelta.y, height);
		}

		private void OnValidate()
		{
			if (rect == null) rect = GetComponent<RectTransform>();
		}
	}
}

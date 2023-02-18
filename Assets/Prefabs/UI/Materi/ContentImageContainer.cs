using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Herghys
{
    public class ContentImageContainer : ContentHolder
    {
        [SerializeField] Image image;

		public override void SetContent(Sprite sprite)
		{
			image.sprite = sprite;
		}

		private void OnValidate()
		{
			if (image is null) image = GetComponentInChildren<Image>();
		}
	}
}
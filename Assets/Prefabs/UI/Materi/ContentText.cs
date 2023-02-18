using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Herghys
{
    public class ContentText : ContentHolder
    {
        [SerializeField] TextMeshProUGUI textUI;

		public override void SetContent(string text)
		{
			textUI.text = text;
		}

		private void OnValidate()
		{
			if (textUI is  null) { textUI = GetComponent<TextMeshProUGUI>(); }
		}
	}
}

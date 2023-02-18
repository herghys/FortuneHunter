using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Herghys
{
	public class ContentSubhead : ContentHolder
	{
		[SerializeField] TextMeshProUGUI textUI;

		public override void SetContent(string text)
		{
			textUI.text = $"<indent=2%><size=95%>{text}</size></indent>";
		}

		private void OnValidate()
		{
			if (textUI is null) { textUI = GetComponent<TextMeshProUGUI>(); }
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Herghys
{
    public class MateriButton : CustomButton
    {
		//[SerializeField] int index;
		[SerializeField] string titleText;

		[SerializeField] TextMeshProUGUI titleUI;

		[SerializeField] SubjectTypes subject;
		[SerializeField] MateriManager manager;
		//public int Index { get => index; set => index = value; }
		public SubjectTypes Subject { get => subject; set => subject = value; }

		private void Awake()
		{
			titleUI.text = titleText;
		}

		public override void OnButtonClicked()
		{
			manager.OpenChild(subject);
		}

		protected override void OnValidate()
		{
			base.OnValidate();
			manager = GetComponentInParent<MateriManager>() as MateriManager;

			titleUI = GetComponentInChildren<TextMeshProUGUI>();

			titleText = subject switch
			{
				SubjectTypes.Ekskresi => "Sistem Eksreksi",
				SubjectTypes.Ginjal => "Ginjal",
				SubjectTypes.Kulit => "Kulit",
				SubjectTypes.Paru => "Paru-Paru",
				SubjectTypes.Hati => "Hati dan Gangguan Sistem Ekskresi",
				_ => "Sistem Eksreksi",
			};
		}
	}
}

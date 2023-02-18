using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herghys
{
    public class MateriManager : UIBase
    {
        [SerializeField] List<MateriButton> materiButtons = new();
		[SerializeField] List<MateriHolder> materiHolders = new();

		public void OpenChild(SubjectTypes subject)
		{
			base.OpenChild();
			foreach (var item in materiHolders)
			{
				if (item.Subject == subject) item.Open();
				else item.Close();
			}
		}

		public void CloseChild(SubjectTypes subject)
		{
			base.CloseChild();
			foreach (var item in materiHolders)
			{
				if (item.Subject == subject) item.Close();
			}
		}

		private void OnValidate()
		{
			if (materiButtons.Count == 0)
				GetComponentsInChildren(true, materiButtons);

			if (materiHolders.Count == 0)
				GetComponentsInChildren(true, materiHolders);
		}
	}
}

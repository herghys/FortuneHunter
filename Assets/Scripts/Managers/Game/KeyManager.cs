using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Herghys
{
    public class KeyManager : MonoBehaviour
    {
		[SerializeField] GameManager manager;
        public List<KeyTarget> keys = new();
		public int total;
		[SerializeField] int currentKeyTotal = 0;

		public void UpdateKey()
		{
			if (currentKeyTotal == total - 1)
			{
				manager.UpdateState?.Invoke(GameState.End);
				currentKeyTotal++;
				return;
			}

			currentKeyTotal++;
		}

		private void OnValidate()
		{
			keys = FindObjectsOfType<KeyTarget>(true).ToList();
			total = keys.Count;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herghys
{
	public class Treasure : MonoBehaviour, IClickable
    {
		[SerializeField] GameManager gameManager;

		private void Awake()
		{
			if (gameManager is null) gameManager = FindObjectOfType<GameManager>(true);
		}

		public void Click()
		{
			throw new System.NotImplementedException();
		}
	}
}

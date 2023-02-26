using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herghys
{
	[CreateAssetMenu(fileName = "Audio Data", menuName = "Data/Audio/BGM")]
	public class BGMAudioData : AudioData
    {
		private void OnValidate()
		{
			audioType = AudioType.BGM;
		}
	}
}

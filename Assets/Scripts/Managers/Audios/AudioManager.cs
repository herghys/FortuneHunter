using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herghys
{
    public class AudioManager : GenericSingleton<AudioManager>
    {
        [SerializeField] int startBGM;
		[SerializeField] AudioSourceController audioPrefab;
		[SerializeField] protected AudioData[] audioData;
		[SerializeField] protected List<AudioSourceController> audioSources;
		public override void OnAwake()
		{
			InitSounds();
		}

		void InitSounds()
        {
			foreach (var item in audioData)
			{
				var source = Instantiate(audioPrefab, transform);
				source.name = item.name;
				source.InitData(item);
				audioSources.Add(source);
			}
        }

		/*AudioSourceController GetController(string name)
		{
			foreach (var item in audioSources)
			{
				if (item.AudioName == name)
				{
					return item;
				}
			}
		}*/


		public void PlaySound(string name)
		{

		}
    }
}

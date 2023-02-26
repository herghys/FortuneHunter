using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herghys
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioSourceController : MonoBehaviour
    {
        [SerializeField] protected AudioSource audioSource;
        [SerializeField] bool isPlaying;
        public bool IsPlaying { get => isPlaying; set => isPlaying = value; }

		private void Awake()
		{
			if (audioSource == null) audioSource= GetComponent<AudioSource>();
		}

		public void InitData(AudioData data, bool shouldStop = false)
		{
			if (shouldStop)
				Stop();

			audioSource.clip = data.Clip;
			audioSource.outputAudioMixerGroup = data.AudioMixerGroup;
			audioSource.loop = data.Loop;
		}

		public void Play()
		{
			audioSource.Play();
			isPlaying= true;
		}

		public void Stop()
		{
			audioSource.Stop();
			isPlaying = false;
		}

		public void PlayOnce(AudioClip clip)
		{
			audioSource.PlayOneShot(clip);
		}




		private void OnValidate()
		{
			audioSource = GetComponent<AudioSource>();
		}
	}
}

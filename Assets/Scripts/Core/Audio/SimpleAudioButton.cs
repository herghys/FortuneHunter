using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Herghys
{
    public class SimpleAudioButton : SimpleAudio
    {
		[SerializeField] protected AudioClip clip;
        [SerializeField] protected Button button;
		[SerializeField] protected AudioSource source;
		private void Awake()
		{
			button = GetComponent<Button>();
			if (source == null) source = GameObject.FindGameObjectWithTag("InterfaceAudio").GetComponent<AudioSource>();
		}

		private void OnEnable()
		{
			button.onClick.AddListener(Play);
		}

		private void OnDisable()
		{
			button.onClick.RemoveListener(Play);
		}

		public void Play()
		{
			source.PlayOneShot(clip);
			//source.Play();
		}

		protected override void OnValidate()
		{
			base.OnValidate();
			button = GetComponent<Button>();
			source = GameObject.FindGameObjectWithTag("InterfaceAudio").GetComponent<AudioSource>();
			//source.playOnAwake = false;
		}
	}
}

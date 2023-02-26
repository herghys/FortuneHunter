using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Herghys
{
    public class AudioData : ScriptableObject
    {
		[SerializeField] protected AudioType audioType;
        [SerializeField] protected AudioMixer audioMixer;
        [SerializeField] protected AudioMixerGroup audioMixerGroup;
        [SerializeField] protected AudioClip clip;
        [SerializeField] protected bool loop;

        public AudioType Type => audioType;
        public AudioMixer Mixer => audioMixer;
        public AudioMixerGroup AudioMixerGroup => audioMixerGroup;
        public string AudioName => name;
        public AudioClip Clip => clip;
        public bool Loop => loop;
    }
}


public enum AudioType
{
    BGM, Music, Ambient, SFX
}
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManagerScript : MonoBehaviour
{
    public static AudioManagerScript audiomanager;
    public AudioMixer audioMixer;

    public AudioMixerGroup mix;

    public Sound[] sounds;

    private void Awake()
    {
        if (audiomanager == null)
            audiomanager = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.outputAudioMixerGroup = mix;
            s.source.clip = s.Clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Start()
    {
        mix = audioMixer.outputAudioMixerGroup;
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    [Serializable]
    public class Sound
    {
        public string name;

        public AudioClip Clip;

        [Range(0f, 1f)] public float volume;

        [Range(0f, 1f)] public float pitch;

        [HideInInspector] public AudioSource source;
    }
}

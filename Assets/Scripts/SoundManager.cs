using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] _audios;
    private AudioSource _controlAudio;
    static private SoundManager _instance;

    static public SoundManager Instance { get { return _instance; } }
    private void Awake()
    {
        _instance = this;
        _controlAudio = GetComponent<AudioSource>();
    }
    public void AudioSelection(int index, float volume)
    {
        _controlAudio.PlayOneShot(_audios[index], volume);
    }
    public void StopAudio()
    {
        _controlAudio.Stop();
    }
}

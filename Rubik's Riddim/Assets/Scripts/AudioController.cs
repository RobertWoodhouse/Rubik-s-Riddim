using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour 
{
	public void PlayAudio(AudioClip clip, AudioSource source)
	{
		source.clip = clip;
		source.Play();
	}

    public void ThemeTrasition()
	{
		
	}
}



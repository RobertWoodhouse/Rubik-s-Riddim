using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour 
{
	[SerializeField]
	public AudioSource _source;

    public AudioSource Source
    {
        get { return _source; }
		set { _source = value; }
    }

	private void Update()
	{
		//ThemeTrasition();
	}

	private void Start()
	{
		GameEvents.current.onPlayAudio += PlayAudio;
		ThemeTrasition();
	}

	public void PlayAudio(AudioClip clip, AudioSource source)
	{
		source.clip = clip;
		source.Play();
        /*
		GameEvents.current.PlaySound(GameObject.FindGameObjectWithTag("Rubiks").GetComponent<AudioModel>().Instruments[0],
                                     //GameObject.FindGameObjectWithTag("Rubiks").GetComponent<AudioModel>().Source);
                                     Source);*/
	}

    public void ThemeTrasition()
	{
		GameEvents.current.PlaySound(GameObject.FindGameObjectWithTag("Rubiks").GetComponent<AudioModel>().Instruments[0],
									 //GameObject.FindGameObjectWithTag("Rubiks").GetComponent<AudioModel>().Source);
									 Source);
	}
}



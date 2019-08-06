using System;
using UnityEngine;

public class GameEvents : MonoBehaviour 
{
	public static GameEvents current;

	private void Awake () 
	{
		current = this;
	}
    
	public event Action<int, string> onTouchpadDown;
    public void TouchpadDown(int id, string direction)
	{
		if (onTouchpadDown != null)
		{
			onTouchpadDown(id, direction);
		}
	}

    // TODO change back from array if multi track fails
	public event Action<AudioClip[], AudioSource> onPlayAudio;
	public void PlaySound(AudioClip[] clip, AudioSource source)
	{
		if (onPlayAudio != null)
		{
			onPlayAudio(clip, source);
		}
	}
}

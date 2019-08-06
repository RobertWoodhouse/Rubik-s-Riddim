using UnityEngine;

public class AudioModel : MonoBehaviour 
{
	[SerializeField]
	private AudioClip[] _intruments;

	public AudioClip[] Instruments
	{
		get { return _intruments; }
		set { _intruments = value; }
	}
    /*
	public AudioSource _source;

	public AudioSource Source
    {
		get { return _source; }
		set { _source = value; }
    }
    */
}

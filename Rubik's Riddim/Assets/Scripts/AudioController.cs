using UnityEngine;

public class AudioController : MonoBehaviour 
{
	[SerializeField]
	private bool[] _channels;
    private AudioSource _source;

    public AudioSource Source // = GameController
    {
        get { return _source; }
        set { _source = value; }
	}

	private AudioSource[] audioSources; // = GetComponents<AudioSource>();
	private GameObject goRubik;

	public void Start()
	{
		audioSources = GetComponents<AudioSource>();
		GameEvents.current.onPlayAudio += PlayAudioTracks;
		ThemeTrasition();
		goRubik = GameObject.FindGameObjectWithTag("Rubiks");
	}

	private void Update()
	{
		MuteAudioTracks(_channels);
		IntrumentsSwitch(goRubik.GetComponent<PieceModel>().PieceCounter, goRubik.GetComponent<PieceModel>().piecesNum);
	}

	private void MuteAudioTracks(bool[] channel)
    {
        //Debug.Log("Channels " + channel.Length);
        if (!channel[0]) audioSources[0].mute = true;
        else audioSources[0].mute = false;

        if (!channel[1]) audioSources[1].mute = true;
        else audioSources[1].mute = false;

        if (!channel[2]) audioSources[2].mute = true;
        else audioSources[2].mute = false;

        if (!channel[3]) audioSources[3].mute = true;
        else audioSources[3].mute = false;

        if (!channel[4]) audioSources[4].mute = true;
        else audioSources[4].mute = false;
    }
    
	private void IntrumentsSwitch(int min, int max)
	{
		//float percent = (min / max) * 100;
		//Debug.Log("Percentage for Intrument Switch: " + percent);

		//Debug.Log("Pieces counter " + PieceController.pieceCounter);
		//Debug.Log("Number of pieces " + PieceController.piecesNum);
		//if (min <= max) _channel[0] = true;
		if (min == 1) _channels[0] = true;
		if (min == 2) _channels[1] = true;
		if (min == 3) _channels[2] = true;
		if (min == 4) _channels[3] = true;
		if (min >= 5) _channels[4] = true;
	}

	public void PlayAudioTracks(AudioClip[] clip, AudioSource source)
	{
		for (int i = 0; i < clip.Length; i++)
		{
			//Debug.Log("Intrument " + i+1);
			audioSources[i].loop = true;
            audioSources[i].clip = clip[i];
            audioSources[i].Play();
		}
	}

    public void ThemeTrasition()
	{
		GameObject go = GameObject.FindGameObjectWithTag("Rubiks");
		Debug.Log("GameObject tag = " + go.tag);
        
		GameEvents.current.PlaySound(go.GetComponent<AudioModel>().Instruments, Source);
		Debug.Log("Intruments currently playing = " + go.GetComponent<AudioModel>().Instruments.Length);

	}
}



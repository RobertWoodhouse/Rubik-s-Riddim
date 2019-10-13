using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    //private Transform background;
    private SpriteRenderer _background;
    private bool _isFade = true;
    //private Color _backgroundColour;
    public float fade = 1.0f;
    
	private void Awake () 
	{
		//background = transform.Find("Background");
        _background = GetComponent<SpriteRenderer>();
        //_backgroundColour = new Color(1,1,1,1);
	}


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //_background.color = new Color(1,2,3,4);

        BackgroundColour();
    }

    void BackgroundColour()
    {
        if (_isFade == true) fade-=0.1f*Time.deltaTime;
            if (fade <= 0.0f) _isFade = false;
        if (_isFade == false) fade+=0.1f*Time.deltaTime;
            if (fade >= 1.0f) _isFade = true;

        //_backgroundColour = new Color(fade,1,1,1);
        //_background.color = _backgroundColour;
        _background.color = new Color(Mathf.SmoothStep(0.0f, 1f, fade),1f,1f,1f);  
    }
}

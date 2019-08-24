using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour 
{

	private Transform bar;
    
	private void Awake () 
	{
		bar = transform.Find("Bar");
		//bar.localScale = new Vector3(.2f, 1.0f);
	}

	private void Update()
	{
		ChangeHealth(GameModel.Health);
	}

	public void ChangeHealth (float healthNorm) 
	{
		bar.localScale = new Vector3(healthNorm, 1.0f);
	}
}

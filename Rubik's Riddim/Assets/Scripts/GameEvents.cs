using System;
using UnityEngine;

public class GameEvents : MonoBehaviour 
{
	public static GameEvents current;

	private void Awake () 
	{
		current = this;
	}
    
	public event Action<int> onTouchpadDown;
    public void TouchpadDown(int id)
	{
		if (onTouchpadDown != null)
		{
			Debug.Log("Test " + this.name);
			onTouchpadDown(id);
		}
	}
}

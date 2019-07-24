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
}

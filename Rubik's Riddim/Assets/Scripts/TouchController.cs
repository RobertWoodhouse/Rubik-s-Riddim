﻿using UnityEngine;

public class TouchController : MonoBehaviour 
{
	private void Update()
	{
		Touchpad();
	}

	private void Touchpad()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

			if (hit != false && hit.collider != null)
			{
				Debug.Log("Currently touching gameobject: " + hit.collider.name);
				GameEvents.current.TouchpadDown(hit.collider.GetComponentInParent<PieceController>().Id); // Pass ID from PieceController script
			}
		}
	}
}

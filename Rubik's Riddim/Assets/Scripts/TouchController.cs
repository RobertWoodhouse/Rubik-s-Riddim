using UnityEngine;

public class TouchController : MonoBehaviour 
{ 
	private void Update()
	{
    	Touchpad();    
		//TouchScreen(); // TODO: fix ArgumentException
	}

	#if UNITY_EDITOR
	private void Touchpad()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

			if (hit != false && hit.collider != null)
			{
				Debug.Log("Currently touching gameObject: " + hit.collider.name + " | direction: " + hit.collider.tag);
				GameEvents.current.TouchpadDown(hit.collider.GetComponentInParent<PieceController>().Id, hit.collider.tag); // Pass ID from PieceController script
			}
		}
	}
	#endif

	#if UNITY_ANDROID
	private void TouchScreen()
    {
        Touch touch = Input.GetTouch(0);
        Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

		if (hit != false && hit.collider != null)
		{
			Debug.Log("Currently touching gameObject: " + hit.collider.name + " | direction: " + hit.collider.tag);
			GameEvents.current.TouchpadDown(hit.collider.GetComponentInParent<PieceController>().Id, hit.collider.tag); // Pass ID from PieceController script
		}
    }
	#endif
}

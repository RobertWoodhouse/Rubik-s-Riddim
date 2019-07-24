using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour 
{
	[SerializeField]
	private int _id;

	public int Id
	{
		get
		{
			return _id;
		}
        set
		{
			_id = value;
		}
	}

	private void Start() 
	{
		GameEvents.current.onTouchpadDown += OnPieceMove;
	}
    
    private void OnPieceMove(int id, string direction)
	{
		if (id == _id)
		{
			Debug.Log("Piece Moved");
            /*
            GameObject go = this.gameObject;
            float x = go.transform.localPosition.x;
            float y = go.transform.localPosition.y;
            float z = go.transform.localPosition.z;
            */

            // Piece Directions
			if (direction == "RightBtn") LeanTween.moveLocalX(gameObject, 5.0f, 1.0f);//go.transform.localPosition = new Vector3(3.2f, y, z);
			if (direction == "LeftBtn") LeanTween.moveLocalX(gameObject, -5.0f, 1.0f);//go.transform.localPosition = new Vector3(-3.2f, y, z);
			if (direction == "UpBtn") LeanTween.moveLocalY(gameObject, 5.0f, 1.0f);//go.transform.localPosition = new Vector3(x, 3.2f, z);
			if (direction == "DownBtn") LeanTween.moveLocalY(gameObject, -5.0f, 1.0f);//go.transform.localPosition = new Vector3(x, -3.2f, z);
		}
	}
    /*
	private void OnCollisionEnter2D(Collision2D coll)
	{
		Debug.Log("Collision Test");
		//if (coll.tag.Equals("Pipe")) LeanTween.moveLocal(gameObject, Vector3, 1.0f);
	}
    */

	private void OnTriggerEnter2D(Collider2D coll)
	{
		Debug.Log("Test Trigger" + coll.gameObject.tag);
	}
}

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
	//TODO: TEST VARS
	//public  int piecesNum = 0;
	//public  int pieceCounter = 0;

	//public string _direction;
	private GameObject _go;
	public static Vector3 _goPos;
	public static bool _hasCollide;

	private void Start() 
	{
		GameEvents.current.onTouchpadDown += OnPieceMove;
		_go = this.gameObject;
		//_hasCollide = false;
	}

	private void OnPieceMove(int id, string direction)
	{
		if (id == _id)
		{
			//Debug.Log("Piece Moved");

			//var _direction = GetComponentInParent<PieceModel>().Direction;
			//_go = this.gameObject;
			_goPos = new Vector3(_go.transform.localPosition.x, _go.transform.localPosition.y, _go.transform.localPosition.z);
			Debug.Log("This GO original POS = " + _goPos);
            
            // Piece Directions
			if (direction == "RightBtn") 
			{
				LeanTween.moveLocalX(gameObject, 5.0f, 2.0f);
				_go.GetComponentInParent<PieceModel>().PieceCounter++;
			}
			if (direction == "LeftBtn")
			{
				LeanTween.moveLocalX(gameObject, -5.0f, 2.0f);
				_go.GetComponentInParent<PieceModel>().PieceCounter++;
			}
			if (direction == "UpBtn")
			{
				LeanTween.moveLocalY(gameObject, 5.0f, 2.0f);
				_go.GetComponentInParent<PieceModel>().PieceCounter++;
			}
			if (direction == "DownBtn")
			{
				LeanTween.moveLocalY(gameObject, -5.0f, 2.0f);
				_go.GetComponentInParent<PieceModel>().PieceCounter++;
			}

			GetComponentInParent<PieceModel>().Direction = direction;
		}
	}

	private IEnumerator OnPieceReturn(GameObject go)
	{
        var _direction = GetComponentInParent<PieceModel>().Direction;
        var goParent = FindParentWithTag(go, "Piece");
        //Debug.Log("Object name " + goParent.name);

		if (_hasCollide == false)
		{
			LeanTween.cancel(goParent); // Cancels Tween moveLoval 
			if (_direction == "RightBtn")
            {
                LeanTween.moveLocal(goParent, _goPos, 1.0f);
				_go.GetComponentInParent<PieceModel>().PieceCounter--;
                Debug.Log("Piece returning to left");
            }
            if (_direction == "LeftBtn")
            {
                LeanTween.moveLocal(goParent, _goPos, 1.0f);
				_go.GetComponentInParent<PieceModel>().PieceCounter--;
                Debug.Log("Piece returning to right");
            }
            if (_direction == "UpBtn")
            {
                LeanTween.moveLocal(goParent, _goPos, 1.0f);
				_go.GetComponentInParent<PieceModel>().PieceCounter--;
                Debug.Log("Piece returning to down");
            }
            if (_direction == "DownBtn")
            {
                LeanTween.moveLocal(goParent, _goPos, 1.0f);
				_go.GetComponentInParent<PieceModel>().PieceCounter--;
                Debug.Log("Piece returning to up");
            }

			_hasCollide = true;
		}
        
		yield return new WaitForSeconds(0.5f);
        
		_hasCollide = false;

		//Debug.Log("Return pos = " + _goPos);

		Debug.Log("Object name " + goParent.name + " Has collided? " + _hasCollide);
	}
    /*
	public void OnCollisionEnter2D(Collision2D coll)
	{
		StartCoroutine(OnPieceReturn(coll.gameObject));
	}
    */
	private void OnTriggerEnter2D(Collider2D coll)
	{
		StartCoroutine(OnPieceReturn(coll.gameObject));
	}

	public static GameObject FindParentWithTag(GameObject childObject, string tag)
    {
        Transform t = childObject.transform;
        while (t.parent != null)
        {
            if (t.parent.tag == tag)
            {
                return t.parent.gameObject;
            }
            t = t.parent.transform;
        }
        return null; // Could not find a parent with given tag.
    }
}

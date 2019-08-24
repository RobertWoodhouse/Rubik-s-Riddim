using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour 
{
	[SerializeField]
	private int _id;
    
	public int Id
	{
		get { return _id; }
		set { _id = value;}
	}

	private GameObject _go;
	private static Vector3 _goPos;
	private static bool _hasCollide;

	private void Start() 
	{
		GameEvents.S.onTouchpadDown += OnPieceMove;
		_go = this.gameObject;
	}

	private void OnPieceMove(int id, string direction)
	{
		if (id == _id)
		{
			_goPos = new Vector3(_go.transform.localPosition.x, _go.transform.localPosition.y, _go.transform.localPosition.z);
			Debug.Log("This GO original POS = " + _goPos);
			float axis;
            
            // Piece Directions
			if (direction == "RightBtn") 
			{
				axis = _goPos.x + 5.0f;
				Debug.Log("GO X moved from " + (axis - 5.0f) + " to " + axis);
				LeanTween.moveLocalX(_go, axis, 2.0f);
				_go.GetComponentInParent<PieceModel>().PieceCounter++;
			}
			if (direction == "LeftBtn")
			{
				axis = _goPos.x - 5.0f;
				Debug.Log("GO X moved from " + (axis + 5.0f) + " to " + axis);
                LeanTween.moveLocalX(_go, axis, 2.0f);
				_go.GetComponentInParent<PieceModel>().PieceCounter++;
			}
			if (direction == "UpBtn")
			{
				axis = _goPos.y + 5.0f;
				Debug.Log("GO Y moved from " + (axis - 5.0f) + " to " + axis);
                LeanTween.moveLocalY(_go, axis, 2.0f);
				_go.GetComponentInParent<PieceModel>().PieceCounter++;
			}
			if (direction == "DownBtn")
			{
				axis = _goPos.y - 5.0f;
				Debug.Log("GO Y moved from " + (axis + 5.0f) + " to " + axis);
                LeanTween.moveLocalY(_go, axis, 2.0f);
				_go.GetComponentInParent<PieceModel>().PieceCounter++;
			}

			GetComponentInParent<PieceModel>().Direction = direction;
		}
	}

	public IEnumerator OnPieceReturn(GameObject go)
	{
        var direction = GetComponentInParent<PieceModel>().Direction;
        var goParent = FindParentWithTag(go, "Piece");

		if (_hasCollide == false)
		{
			LeanTween.cancel(goParent); // Cancels Tween moveLoval 

			if (direction == "RightBtn")
            {
                LeanTween.moveLocal(goParent, _goPos, 1.0f);
				_go.GetComponentInParent<PieceModel>().PieceCounter--;
				GameModel.Health -= .25f;
                Debug.Log("Piece returning to left");
            }
			if (direction == "LeftBtn")
            {
                LeanTween.moveLocal(goParent, _goPos, 1.0f);
				_go.GetComponentInParent<PieceModel>().PieceCounter--;
				GameModel.Health -= .25f;
                Debug.Log("Piece returning to right");
            }
			if (direction == "UpBtn")
            {
                LeanTween.moveLocal(goParent, _goPos, 1.0f);
				_go.GetComponentInParent<PieceModel>().PieceCounter--;
				GameModel.Health -= .25f;
                Debug.Log("Piece returning to down");
            }
			if (direction == "DownBtn")
            {
                LeanTween.moveLocal(goParent, _goPos, 1.0f);
				_go.GetComponentInParent<PieceModel>().PieceCounter--;
				GameModel.Health -= .25f;
                Debug.Log("Piece returning to up");
            }

			_hasCollide = true;
		}
        
		yield return new WaitForSeconds(0.5f);
        
		_hasCollide = false;

		//Debug.Log("Return pos = " + _goPos);

		//Debug.Log("Object name " + goParent.name + " Has collided? " + _hasCollide);
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

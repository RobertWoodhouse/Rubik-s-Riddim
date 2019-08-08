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
	public  int piecesNum = 0;
	public  int pieceCounter = 0;

	//public string _direction;
	private GameObject _go;
	public float _x;
	public float _y;
	private float _z;

	private void Start() 
	{
		GameEvents.current.onTouchpadDown += OnPieceMove;
		//piecesNum = GameObject.FindGameObjectsWithTag("Piece").Length;

		//Debug.Log("Number of pieces = " + piecesNum);
	}
    
    private void OnPieceMove(int id, string direction)
	{
		if (id == _id)
		{
			//Debug.Log("Piece Moved");

			//var _direction = GetComponentInParent<PieceModel>().Direction;
			_go = this.gameObject;
			_x = _go.transform.localPosition.x;
			_y = _go.transform.localPosition.y;
			_z = _go.transform.localPosition.z;
            
            // Piece Directions
			if (direction == "RightBtn") 
			{
				LeanTween.moveLocalX(gameObject, 5.0f, 2.0f);
				_go.GetComponentInParent<PieceModel>().PieceCounter++;
				//pieceCounter++;
			}
			if (direction == "LeftBtn")
			{
				LeanTween.moveLocalX(gameObject, -5.0f, 2.0f);
				_go.GetComponentInParent<PieceModel>().PieceCounter++;
				//pieceCounter++;
			}
			if (direction == "UpBtn")
			{
				LeanTween.moveLocalY(gameObject, 5.0f, 2.0f);
				_go.GetComponentInParent<PieceModel>().PieceCounter++;
				//pieceCounter++;
			}
			if (direction == "DownBtn")
			{
				LeanTween.moveLocalY(gameObject, -5.0f, 2.0f);
				_go.GetComponentInParent<PieceModel>().PieceCounter++;
				//pieceCounter++;
			}

			GetComponentInParent<PieceModel>().Direction = direction;
			//_direction = direction;
		}
	}

	private void OnTriggerEnter2D(Collider2D coll)
	{
		//Debug.Log("Collission detected trigger " + coll.gameObject.tag + " direction " + _direction);
		var _direction = GetComponentInParent<PieceModel>().Direction;

		if (_direction == "RightBtn")
		{
			//LeanTween.moveLocal(this.gameObject, new Vector3(_x, _y, _z), 1.0f);
			LeanTween.moveLocalX(coll.gameObject, -5.0f, 2.0f);
			Debug.Log("Piece returning to left");
		}
		if (_direction == "LeftBtn")
		{
			//LeanTween.moveLocal(this.gameObject, new Vector3(_x, _y, _z), 1.0f);
			LeanTween.moveLocalX(coll.gameObject, 5.0f, 2.0f);
			Debug.Log("Piece returning to right");
		}
		if (_direction == "UpBtn")
		{
			//LeanTween.moveLocal(this.gameObject, new Vector3(_x, _y, _z), 1.0f);
			LeanTween.moveLocalY(coll.gameObject, -5.0f, 2.0f);
			Debug.Log("Piece returning to down");
		}
		if (_direction == "DownBtn")
		{
			//LeanTween.moveLocal(this.gameObject, new Vector3(_x, _y, _z), 1.0f);
			LeanTween.moveLocalY(coll.gameObject, 5.0f, 2.0f);
			Debug.Log("Piece returning to up");
		}
	}
}

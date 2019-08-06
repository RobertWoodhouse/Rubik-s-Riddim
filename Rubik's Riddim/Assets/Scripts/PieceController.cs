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

	private string _direction;
	private GameObject _go;
	private float _x;
	private float _y;
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

			_go = this.gameObject;
			_x = _go.transform.localPosition.x;
			_y = _go.transform.localPosition.y;
			_z = _go.transform.localPosition.z;
            
            // Piece Directions
			if (direction == "RightBtn") 
			{
				LeanTween.moveLocalX(gameObject, 5.0f, 1.0f);
				_go.GetComponentInParent<PieceModel>().PieceCounter++;
				//pieceCounter++;
			}
			if (direction == "LeftBtn")
			{
				LeanTween.moveLocalX(gameObject, -5.0f, 1.0f);
				_go.GetComponentInParent<PieceModel>().PieceCounter++;
				//pieceCounter++;
			}
			if (direction == "UpBtn")
			{
				LeanTween.moveLocalY(gameObject, 5.0f, 1.0f);
				_go.GetComponentInParent<PieceModel>().PieceCounter++;
				//pieceCounter++;
			}
			if (direction == "DownBtn")
			{
				LeanTween.moveLocalY(gameObject, -5.0f, 1.0f);
				_go.GetComponentInParent<PieceModel>().PieceCounter++;
				//pieceCounter++;
			}

			_direction = direction;
		}
	}

	private void OnTriggerEnter2D(Collider2D coll)
	{
		Debug.Log("Collission detected trigger " + coll.gameObject.tag + " direction " + _direction);
        
		if (_direction == "RightBtn") LeanTween.moveLocal(gameObject, new Vector3(_x, _y, _z), 0.5f);;
		if (_direction == "LeftBtn") LeanTween.moveLocal(gameObject, new Vector3(_x, _y, _z), 0.5f);;
		if (_direction == "UpBtn") LeanTween.moveLocal(gameObject, new Vector3(_x, _y, _z), 0.5f);;
		if (_direction == "DownBtn") LeanTween.moveLocal(gameObject, new Vector3(_x, _y, _z), 0.5f);;
	}
}

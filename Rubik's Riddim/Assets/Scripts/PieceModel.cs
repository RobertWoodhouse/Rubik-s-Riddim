using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceModel : MonoBehaviour 
{
	public int piecesNum = 0;
    public int pieceCounter = 0;
    
	private string _direction;

	public int PieceNum
    {
		get { return piecesNum; }
    }

	public int PieceCounter
    {
		get { return pieceCounter; }
		set { pieceCounter = value; }
    }

    public string Direction
	{
		get { return _direction; }
		set { _direction = value; }
	}

	// Use this for initialization
	void Start () 
	{
		piecesNum = GameObject.FindGameObjectsWithTag("Piece").Length;

        Debug.Log("Number of pieces = " + piecesNum);
	}
}

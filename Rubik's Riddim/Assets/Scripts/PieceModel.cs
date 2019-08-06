using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceModel : MonoBehaviour 
{
	public int piecesNum = 0;
    public int pieceCounter = 0;

	public int PieceCounter
    {
        get
        {
			return pieceCounter;
        }
        set
        {
			pieceCounter = value;
        }
    }

	// Use this for initialization
	void Start () 
	{
		piecesNum = GameObject.FindGameObjectsWithTag("Piece").Length;

        Debug.Log("Number of pieces = " + piecesNum);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

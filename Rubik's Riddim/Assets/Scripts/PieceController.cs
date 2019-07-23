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

    // TODO Pass Tag and Piece ID
    private void OnPieceMove(int id)
	{
		if (id == _id)
		{
			Debug.Log("Piece Moved");

            GameObject go = this.gameObject;
            float x = go.transform.localPosition.x;
            float y = go.transform.localPosition.y;
            float z = go.transform.localPosition.z;

            // Move Right
            go.transform.localPosition = new Vector3(3.2f, y, z);

			// Move Left...

			// Move Up...

			// Move Down...
		}
        
        //TODO: Add Direction of child transform
        /*
        switch (shieldDirection)
        {
            case "left":
                for (float f = 1f; f >= 0; f -= time)
                {
                    Debug.Log("Shield child transaitioning in..." + (int)f * 10);
                    //GameObject.Find(raycastHitName).transform.localPosition = new Vector3(x -= .1f, y, z);
                    go.transform.localPosition = new Vector3(x -= speed, y, z);
                    yield return new WaitForSeconds(time);
                }
                break;

            case "right":
                for (float f = 1f; f >= 0; f -= time)
                {
                    Debug.Log("Shield child transaitioning in..." + (int)f * 10);
                    //GameObject.Find(raycastHitName).transform.localPosition = new Vector3(x += .1f, y, z);
                    go.transform.localPosition = new Vector3(x += speed, y, z);
                    yield return new WaitForSeconds(time);
                }
                break;
        }
        */

	}
}

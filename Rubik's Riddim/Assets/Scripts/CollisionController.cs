using UnityEngine;

public class CollisionController : MonoBehaviour 
{
	private void OnTriggerEnter2D(Collider2D coll)
    {
		StartCoroutine(gameObject.GetComponentInParent<PieceController>().OnPieceReturn(coll.gameObject));
    }
}

using UnityEngine;

public class GameModel : MonoBehaviour
{
	private static int _score = 0;
	private static float _health = 1.0f;

	public static int Score
	{
		get { return _score; }
		set { _score = value; }
	}

	public static float Health
    {
		get { return _health; }
		set { _health = value; }
    }
}

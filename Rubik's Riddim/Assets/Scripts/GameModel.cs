using UnityEngine;

public class GameModel : MonoBehaviour
{
	private static int _score = 0;
	private static int _health = 5;

	public static int Score
	{
		get { return _score; }
		set { _score = value; }
	}

	public static int Health
    {
        get { return _score; }
        set { _score = value; }
    }
}

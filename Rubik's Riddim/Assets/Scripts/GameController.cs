using UnityEngine;

public class GameController : MonoBehaviour 
{
    public void SolveRubik(int counter, int num)
	{
		if (counter >= num) 
			Debug.Log("YOU WIN!!");
	}

    public void HealthDecrease(float health)
	{
		if (health <= 0)
			Debug.Log("Game Over...");
	}

    public void ScoreUpdate()
	{
		
	}

	// Update is called once per frame
	void Update () 
	{
		SolveRubik(GameObject.FindWithTag("Rubiks").GetComponent<PieceModel>().PieceCounter, GameObject.FindWithTag("Rubiks").GetComponent<PieceModel>().PieceNum);
		HealthDecrease(GameModel.Health);
	}
}

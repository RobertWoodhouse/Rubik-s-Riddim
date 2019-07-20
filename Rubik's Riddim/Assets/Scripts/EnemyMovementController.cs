using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyMovementController
{	
}

public class EnemyMovementController : IEnemyMovementController 
{
	public void BasicDown()
    {
//        _enemySpeedX = Random.Range(enemySpeedXMin, enemySpeedXMax);

  //      _enemyRB.AddForce(-transform.up * _enemySpeedX); // Vertical Down Speed
    }
}

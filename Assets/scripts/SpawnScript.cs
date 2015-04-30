using System;
using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour
{
// Enemys
		public GameObject[] enemy;
		public float EnemeySpeed; //Velocidade de subida -- definido pelo Gravity Scale negativo
		public float EnemyNum;//Numero de inimigos a serem lançados
		public float EnemyCurrNum = 0; //numero atual de inimigos lançados
		//public float EnemyCount;
// Velocidade de Spawn
		public float spawnTime = 2;
		Vector2 spawnPoint;
		float x1;
		float x2;


		void  Start ()
		{  
				// Call the 'addEnemy' function every 'spawnTime' seconds
				InvokeRepeating ("addEnemy", spawnTime, spawnTime);
		}

		void Update ()
		{
				//EnemyCount = EnemyCurrNum-1;
		}

// New function to spawn an enemy
		void  addEnemy ()
		{  
				if (EnemyCurrNum <= (EnemyNum - 1)) {
						// Variables to store the X position of the spawn object
						// See image below
						x1 = transform.position.x - renderer.bounds.size.x / 2;
						x2 = transform.position.x + renderer.bounds.size.x / 2;

						// Randomly pick a point within the spawn object
						spawnPoint = new Vector2 (UnityEngine.Random.Range (x1, x2), transform.position.y);

						// Create an enemy at the 'spawnPoint' position
						GameObject clone;
						clone = Instantiate (enemy [0], spawnPoint, Quaternion.identity)as GameObject;
						clone.rigidbody2D.gravityScale = - EnemeySpeed;
						EnemyCurrNum++;
						//print (EnemyCurrNum-1);
						
				}
		}
		//when EnemyDies
		//public void PlusDeath()
		//{
		//EnemyCountDead = EnemyCountDead+1;	
		//}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiceGenScript : MonoBehaviour 
{
	// Array variables for store 'instantiate position' and pieces
	public Transform[] spawnPos;
	public GameObject[] piece;
	public GameObject gManager;



	public float musicSpeed = 0.1f;

	//rate of instantiating
	private float nextPiece = 0.0f;
	private float nextLevelUp = 0.0f;
	public float pieceRate = 1.0f;
	public float levelUpTime = 20.0f; 
	public int currentLevel = 1;

	//bomb charge
	public int bombs = 0;

	//increases the difficulty by incriesing the number of pieces per second
	public float difficulty = 0.1f;
    public float minimumRate = 1.0f;


	void Start()
	{
		nextLevelUp = Time.time + levelUpTime;
	}

    // Update is called once per frame
    void Update () 
	{
		if (Time.time > nextPiece)
		{
			nextPiece = Time.time + pieceRate;
			DropPiece();
		}

		if (Time.time > nextLevelUp && GameManager.gm.score >= 6)
		{
			currentLevel ++;

			//Limit minimum rate
			if (pieceRate >= minimumRate)
			{
				pieceRate -= difficulty;
				gManager.GetComponent<AudioSource>().pitch += musicSpeed;
				nextLevelUp = Time.time + levelUpTime;
			}
		}

	}

	public void DropPiece()
	{
		if(GameManager.gm.dropBomb == true && bombs >=1)
		{
			Instantiate(piece[Random.Range(4,8)],spawnPos[Random.Range(0, (spawnPos.Length))].position,transform.rotation);
			bombs --;
		}
			
		else
		{
			Instantiate(piece[Random.Range(0,4)],spawnPos[Random.Range(0, (spawnPos.Length))].position,transform.rotation);
		}
	}
}

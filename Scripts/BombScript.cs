using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour 
{
	public GameObject[] xploding;
	public string color;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		
	}

	public void Detonate()
	{
		xploding = GameObject.FindGameObjectsWithTag(color);
		foreach (GameObject xplode in xploding)
		{
			xplode.GetComponent<MatchPieces>().Xplode();
			Destroy(gameObject);		
		}
	}
}

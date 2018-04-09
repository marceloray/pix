using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinamicPosition : MonoBehaviour 
{
	private Vector3 cameraPos;
	private Vector2 screenSize;

	public int offsetY = 0;

	// Use this for initialization
	void Start () 
	{
		//Generate world space point information for position and scale calculations
		cameraPos = Camera.main.transform.position;
		screenSize.x = Vector2.Distance (Camera.main.ScreenToWorldPoint(new Vector2(0,0)),Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0))) * 0.5f;
		screenSize.y = Vector2.Distance (Camera.main.ScreenToWorldPoint(new Vector2(0,0)),Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height))) * 0.5f;

		//Set position
		transform.position = new Vector3(cameraPos.x, cameraPos.y + (screenSize.y + offsetY), 0);

		
	}
}

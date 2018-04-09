using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour
{
    public float controllIntensity;

    public GameObject children;

    PieceManager pm;

    void Awake()
    {
            // Transform child = gameObject.transform.GetChild(0);
    }

    // Use this for initialization
    void Start () 
	{
        pm = children.GetComponent<PieceManager>();


    }
	
	// Update is called once per frame
	void Update () 
	{
        if (!pm.isGrounded)
		transform.Translate((Input.acceleration.x * controllIntensity), 0,0);
	}
}

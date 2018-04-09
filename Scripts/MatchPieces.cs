using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchPieces : MonoBehaviour
{
    public string color;
    public Transform parent;
    public GameObject explosion;

    [HideInInspector]
    public CameraShaker shake;


	// Use this for initialization
	void Start () {
        shake = GameObject.Find("Main Camera").GetComponent<CameraShaker>();
        
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        
	    
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == color)
        {
			Xplode();
        }
        
    }

	public void Xplode()
	{
		Destroy(transform.parent.gameObject);
		Instantiate(explosion, transform.parent.position, transform.parent.rotation);
		shake.shouldShake = true;
		GameManager.gm.score ++;
		GameManager.gm.refreshGUI();
	}

}

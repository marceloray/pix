using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour
{

    public bool isGrounded = false;
	public float rotateSpeed = 1.0f;




    void Awake()
    {
		//GameManager gm = new GameManager();
        transform.Rotate(0, 0, (Random.Range(0, 3) * 90));
    }

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "fixed")
        {
			if(transform.position.y >= GameManager.gm.limit.position.y)
			{
				GameManager.gm.GameOver();
			}

			if(transform.position.y >= GameManager.gm.dropBombsLimit.position.y)
			{
				GameManager.gm.dropBomb = true;
			}

            gameObject.tag = "fixed";
            isGrounded = true;
        }
    }

	public void CallRotate()
	{
		Debug.Log("entrou CallRotate");
		//StartCoroutine("Rotate");
		Rotate90();
	}

	IEnumerator Rotate()
	{
		transform.Rotate(0, 0, 90);

		//Debug.Log ("Start Coroutine Rotate");
//		float startRotation = transform.rotation.z;
//		float endRotation = startRotation + 90f;
//		while (endRotation - transform.rotation.z > 1f)
//		{
//			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, endRotation), rotateSpeed * Time.deltaTime);
//			//startRotation = transform.rotation.z;
//			//Debug.Log(transform.rotation.z);
//
//			yield return null;	
//		}
		yield return null;
	}

	public void Rotate90()
	{
		transform.Rotate(0, 0, 90);
	}



}

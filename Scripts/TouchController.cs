using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchController : MonoBehaviour
{
    public float distance = 10f;
    public LayerMask layermask;
    public float pushForce = 1;

	//rotation at touch speed variation
	public float speed = 1.0f;

    RaycastHit2D hit;




    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame

    void Update ()
    {

        for (int i = 0; i < Input.touchCount; ++i)
        {
			//Input.GetTouch(i).radiusVariance = 2f;
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
            hit = Physics2D.Raycast(pos, Vector2.zero);
			//Input.GetTouch (i).radius += 1f;


			//Debug.Log("radius= " + Input.GetTouch (i).radius);
			//Debug.Log("radiusVariance= " + Input.GetTouch (i).radiusVariance);

                //Quaternion originalRotation = hit.collider.transform.rotation;


			if (Input.GetTouch(i).phase == TouchPhase.Began)
			{
				if (hit.collider != null)
				{
					if (hit.collider.gameObject.layer == 10)
					{
						hit.collider.GetComponent<BombScript>().Detonate();
					}
				}
			}

            if (Input.GetTouch(i).phase == TouchPhase.Ended)
            {
                if (hit.collider != null)
                {
                    if (hit.collider.tag != "fixed")
                    {
                        if (hit.collider.gameObject.layer == 8)
                        {
                            hit.collider.transform.Rotate(0, 0, 90);
                        }

                    }
                }
            }

            if (Input.GetTouch(i).phase == TouchPhase.Moved)
            {
                if (hit.collider != null)
                {
                    if (hit.collider.tag != "fixed")
                    {
                        if (hit.collider.gameObject.layer == 8)
                        {
                           // hit.transform.rotation = originalRotation;
                            hit.collider.GetComponent<Rigidbody2D>().drag = pushForce;
                        }
                    }
                }
            }



        }
    }


}

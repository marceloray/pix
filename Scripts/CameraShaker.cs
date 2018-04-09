using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour {

    public float power = 0.7f;
    public float duration = 1.0f;
    public Transform mainCamera;
    public float slowDownAmount = 1.0f;
    public bool shouldShake = false;

    //private variables
    Vector3 startPosition;
    float initialDuration;
    

	// Use this for initialization
	void Start () {
        mainCamera = Camera.main.transform;
        startPosition = mainCamera.localPosition;
        initialDuration = duration;
	}
	
	// Update is called once per frame
	void Update () {
        if(shouldShake)
        {
            if(duration > 0)
            {
                mainCamera.localPosition = startPosition + Random.insideUnitSphere * power;
                duration -= Time.deltaTime * slowDownAmount;
            }
            else
            {
                shouldShake = false;
                duration = initialDuration;
                mainCamera.localPosition = startPosition;
            }
        }
		
	}
}

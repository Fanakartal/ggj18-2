using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour {

	public Vector2 touchPos;
    public Vector3 mousePos;
    private Camera mainCam;
    public GameObject touchArea;

    public GameObject circularWave;
    public static uint concurrentWaves;
    // Use this for initialization
	void Start () 
    {
        mainCam = Camera.main;
        concurrentWaves = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(Input.GetMouseButtonDown(0))
        {
            //concurrentWaves++;
            //Debug.Log("Mouse clicked at: " + Input.mousePosition);

            mousePos = Input.mousePosition;
            mousePos.z = 20.0f;

            //if(concurrentWaves<= 3)
                CreateCircularWave(mainCam.ScreenToWorldPoint(mousePos));

            //touchArea.transform.position = 
            //    mainCam.ScreenToWorldPoint(mousePos);
        }
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);         
            
            switch (touch.phase)
            {
                // Record initial touch position.
                case TouchPhase.Began:                   
                    touchPos = touch.position;

                    Debug.Log("Began: " + mainCam.ScreenToWorldPoint(touchPos));

                    touchArea.transform.position = mainCam.ScreenToWorldPoint(touchPos);
                    CreateCircularWave(mainCam.ScreenToWorldPoint(touchPos));
                    /*if (touchArea.GetComponent<CircleCollider2D>().OverlapPoint(mainCam.ScreenToWorldPoint(startPos)))
                    {
                        Debug.Log("ContainsFinger");
                    }*/
               
                break;
                
                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    //if (canMove)
                    //{
                        //transform.position = new Vector3(transform.position.x, mainCam.ScreenToWorldPoint(touch.position).y, transform.position.z);
                    //}

                    break;
                
                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    Debug.Log("Ended");
                    //canMove = false;
                    break;
            }
        }	
	}

    private void CreateCircularWave(Vector3 wavePos)
    {
        concurrentWaves++;
        //Debug.Log(concurrentWaves + "vawes");
        Instantiate(circularWave, wavePos, Quaternion.identity);
    }
}

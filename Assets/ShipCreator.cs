using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCreator : MonoBehaviour {

    public GameObject ship;
    public int arrivedShipCount;
    public GameObject arrivedShipCountText;
    // Use this for initialization
	void Start () 
    {
        arrivedShipCount = 0;
        InvokeRepeating("CreateShip", 2.0f, Random.Range(2.0f, 4.0f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void CreateShip()
    {
        Instantiate(ship, new Vector2(12.0f, Random.Range(4.4f, -4.4f)), Quaternion.identity);
        //newShip.transform.Rotate(0.0f, 0.0f, -90.0f);
        
        //yield return new WaitForSeconds(5.0f);
    }
}

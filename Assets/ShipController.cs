using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipController : MonoBehaviour {

    private Vector2 _newPosition;

    public GameObject _gameManager;
    // Use this for initialization
	void Start () 
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager");
        
        transform.Rotate(0.0f, 0.0f, -90.0f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(-5.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () 
    {
        SinusMovement();	
	}

    private void SinusMovement()
    {
        _newPosition = transform.position;
        _newPosition.y += Mathf.Sin(Time.time) * Time.deltaTime;
        transform.position = _newPosition;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Destination")
        {
            _gameManager.GetComponent<ShipCreator>().arrivedShipCount++;
            _gameManager.GetComponent<ShipCreator>().arrivedShipCountText.GetComponent<Text>().text 
                = "ARRIVED SHIPS: " + _gameManager.GetComponent<ShipCreator>().arrivedShipCount;
            Destroy(this.gameObject, 2.75f);
        }
    }
}

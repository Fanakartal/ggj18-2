using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waver : MonoBehaviour {

    // Use this for initialization
	void Start () 
    {
        StartCoroutine(ScaleWave());
	}

    private IEnumerator ScaleWave()
    {
        for(int i = 0; i<120; i++)
        {
            transform.localScale += new Vector3(0.05f*i, 0.05f*i, 0.0f);
            yield return new WaitForSeconds(0.05f);

            if (transform.localScale.x >= 10.0f)
                Destroy(this.gameObject, 0.75f);
        }  
    }
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ship")
        {
            //Destroy(other.gameObject);
            //TouchController.concurrentWaves--;
            ///Debug.Log("dalgasayısı: "+ TouchController.concurrentWaves);
            Destroy(this.gameObject, 0.75f);
        }

        if(other.gameObject.tag == "Destination")
        {
            //TouchController.concurrentWaves--;
            //Debug.Log("dalgasayısı: " + TouchController.concurrentWaves);
            Destroy(this.gameObject, 0.75f);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ship")
        {
            try
            {
                other.gameObject.GetComponent<Rigidbody2D>().velocity
                    = new Vector2(2 * other.contacts[0].normal.x * other.gameObject.GetComponent<Rigidbody2D>().velocity.x,
                        2 * other.contacts[0].normal.y * other.gameObject.GetComponent<Rigidbody2D>().velocity.y);
            }
            catch(Exception ioobe)
            {
                Debug.Log(ioobe.ToString());
            }

            this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}

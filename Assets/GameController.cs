using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject playButton;
    public GameObject gameText;
    public GameObject inGameText;
    
    // Use this for initialization
	void Start () 
    {
        inGameText.SetActive(false);
        Time.timeScale = 0.0f;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayTheGame()
    {
        Time.timeScale = 1.0f;
        playButton.SetActive(false);
        gameText.SetActive(false);
        inGameText.SetActive(true);
    }
}

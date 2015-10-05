using UnityEngine;
using System.Collections;

public class TitleScreenMain : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.level = 1;
            Application.LoadLevel("MainGame");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameManager.level = 8;
            Application.LoadLevel("MainGame");
        }
	}
}

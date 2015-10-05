using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverMain : MonoBehaviour {

    public Text scoreLabel;
    public Text highscoreLabel;
    void Start()
    {
        scoreLabel.text = "Total score: " + GameManager.score;
        highscoreLabel.text = "Highscore: " + PlayerPrefs.GetInt("Highscore");
        if (Random.Range(0, 100) < 10)
            GameObject.Find("EasterEgg").GetComponent<BlinkingText>().enabled = true;
        StartCoroutine(UpdateOnline());
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
            GameManager.level = 9;
            Application.LoadLevel("MainGame");
        }
	}

    IEnumerator UpdateOnline()
    {
        string user = PlayerPrefs.GetString("user");

        WWWForm form = new WWWForm();
        form.AddField("user", user);
        form.AddField("score", PlayerPrefs.GetInt("Highscore"));

        WWW download = new WWW(GameManager.SERVER_ADDRESS + "set_score", form);

        yield return download;
    }
}

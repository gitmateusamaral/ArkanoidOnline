using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnterName : MonoBehaviour 
{
	private InputField inputF;
	
	void Start()
	{
		inputF = GetComponent<InputField>();
	}
	
	void Update () 
	{
		if(Input.GetKey(KeyCode.Return))
		{
            if (inputF.text.Trim() != "" && inputF.text.IndexOfAny(new char[] { '&', ';', '!', '@', '#', '$', '%', '*', '(', ')' }) == -1)
            {
                PlayerPrefs.SetString("user", inputF.text);
                StartCoroutine(GetHighscore());
            }
            else
            {
                inputF.text = "";
                Text placeholder = inputF.placeholder.gameObject.GetComponent<Text>();
                placeholder.text = "Please enter a valid user and press enter";
                placeholder.color = Color.white;
                inputF.image.color = Color.red;
            }
		}
	}

    IEnumerator GetHighscore()
    {
        string user = PlayerPrefs.GetString("user");

        WWWForm form = new WWWForm();
        form.AddField("user", user);

        WWW download = new WWW(GameManager.SERVER_ADDRESS + "get_score", form);

        yield return download;

        if (!string.IsNullOrEmpty(download.error))
        {
            print("Error downloading: " + download.error);
        }
        else
        {
            if (download.text != "-1")
                PlayerPrefs.SetInt("Highscore", int.Parse(download.text.Split(';')[0]));
        }
        Application.LoadLevel("TitleScreen");
    }
}
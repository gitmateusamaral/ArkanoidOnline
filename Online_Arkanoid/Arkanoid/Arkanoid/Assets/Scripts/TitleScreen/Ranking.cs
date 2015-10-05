using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Ranking : MonoBehaviour {

    private Text text;
	
	void Start () {
        text = GetComponent<Text>();
        StartCoroutine(GetOnline());
	}

    IEnumerator GetOnline()
    {
        WWW download = new WWW(GameManager.SERVER_ADDRESS + "get_ranking");

        yield return download;

        if (!string.IsNullOrEmpty(download.error))
        {
            print("Error downloading: " + download.error);
        }
        else
        {
            string str = "Ranking: ";

            string[] datas = download.text.Split(';');
            foreach (string data in datas)
            {
                if (data.Trim() != "")
                {
                    string[] values = data.Split('&');
                    str += "\n " + values[0] + " => " + values[1];
                }
            }
            text.text = str;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class BlinkingText : MonoBehaviour {

    public float time = 1;
    private Text text;

	void Start () {
        text = GetComponent<Text>();
        StartCoroutine(Blink());
	}

    IEnumerator Blink()
    {
        yield return new WaitForSeconds(time);
        text.enabled = !text.enabled;
        StartCoroutine(Blink());
    }
}

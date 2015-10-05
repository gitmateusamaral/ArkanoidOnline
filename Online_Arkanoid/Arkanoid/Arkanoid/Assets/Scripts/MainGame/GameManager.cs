using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public static string SERVER_ADDRESS = "http://patrickpissurno.hol.es/arkanoid_hw.php?act=";

    public static int score = 0;
    public Text scoreLabel;
    public GameObject brick_prefab;
    public static List<GameObject> bricks;
    private int x_count = 10;//13;
    private float block_size = .72f;//0.48f;
    public Color32[] Colors;

    public static int level = 1;

	// Use this for initialization
	void Start () {
        score = 0;
        bricks = new List<GameObject>();
        GenerateLevel();
	}
	
	// Update is called once per frame
	void Update () {
        bricks.Remove(null);
        if (bricks.Count == 0)
        {
            level++;
            GenerateLevel();
            GameObject.Find("Ball").GetComponent<BallMain>().Launch();
        }
        scoreLabel.text = "Score: " + score;
	}

    void GenerateLevel()
    {
        GameObject father = GameObject.Find("Bricks");
        if (father == null)
            father = new GameObject("Bricks");
        int c = 0;
        for (int y = 0; y < level; y++)
        {
            for (int x = 0; x < x_count; x++)
            {
                GameObject brick = Instantiate(brick_prefab, new Vector2(transform.position.x - x_count / 2 * block_size + x * block_size, transform.position.y - y * block_size), Quaternion.identity) as GameObject;
                brick.GetComponent<SpriteRenderer>().color = Colors[c];
                brick.transform.parent = father.transform;
                bricks.Add(brick);

                if (c < Colors.Length - 1)
                    c++;
                else
                    c = 0;
            }
        }
    }
}

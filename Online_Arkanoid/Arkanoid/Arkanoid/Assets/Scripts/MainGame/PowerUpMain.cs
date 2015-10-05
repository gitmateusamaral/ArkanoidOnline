using UnityEngine;
using System.Collections;

public class PowerUpMain : MonoBehaviour {

    public SpriteRenderer up;
    public SpriteRenderer down;

    public int effect;
	// Use this for initialization
	void Start () {
        Collider2D col = GetComponent<Collider2D>();
        foreach (GameObject brick in GameManager.bricks)
        {
            if (brick != null)
            {
                foreach (Collider2D brick_col in brick.GetComponentsInChildren<Collider2D>())
                {
                    if(brick_col != null)
                        Physics2D.IgnoreCollision(col, brick_col, true);
                }
            }
        }
        Physics2D.IgnoreCollision(col, GameObject.Find("Ball").GetComponent<Collider2D>(), true);
        effect = Random.Range(0, 2);
        if (effect == 2)
            effect = 1;
        up.enabled = effect == 0;
        down.enabled = effect == 1;
	}

    void FixedUpdate()
    {
        transform.position += new Vector3(0, -.3f, 0) * 0.05f;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            case "PlayerBody":
            case "PlayerLeftEdge":
            case "PlayerRightEdge":
                PlayerMain player = col.transform.parent.parent.GetComponent<PlayerMain>();
                if (effect == 0)
                {
                    if (player.Size < 1)
                        player.Size++;
                    else
                        player.Size = 1;
                    GameManager.score += 3;
                }
                else
                {
                    if (player.Size > -1)
                        player.Size--;
                    else
                        player.Size = -1;
                    if (GameManager.score - 3 >= 0)
                        GameManager.score -= 3;
                    else
                        GameManager.score = 0;
                }
                Destroy(gameObject);
                break;
            case "GameOver":
                Destroy(gameObject);
                break;
        }
    }
}

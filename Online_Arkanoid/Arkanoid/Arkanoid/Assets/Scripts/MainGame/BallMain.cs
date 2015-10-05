using UnityEngine;
using System.Collections;

public class BallMain : MonoBehaviour {

    public Vector2 speed;
    private Vector3 startingPos;
	// Use this for initialization
	void Start () {
        startingPos = transform.position;
        Launch();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Move();
	}

    void OnCollisionStay2D(Collision2D col)
    {
        Debug.Log(col.gameObject.tag);
        switch (col.gameObject.tag)
        {
            case "WallSide":
                speed.x *= -1;
                Move();
                break;
            case "WallTop":
                speed.y *= -1;
                Move();
                break;
            case "GameOver":
                int highscore = PlayerPrefs.GetInt("Highscore");
                if (GameManager.score > highscore)
                    PlayerPrefs.SetInt("Highscore", GameManager.score);
                Application.LoadLevel("GameOver");
                break;
            case "BrickUD":
                speed.y *= -1;
                BrickCollision(col);
                break;
            case "BrickLR":
                speed.x *= -1;
                BrickCollision(col);
                break;
            case "BrickEdgeRD":
                if(speed.x < 0)
					speed.x *= -1f;
				if(speed.y > 0)
					speed.y *= -1f;
                BrickCollision(col);
                break;
			case "BrickEdgeRU":
				if(speed.x < 0)
					speed.x *= -1f;
				if(speed.y < 0)
					speed.y *= -1f;
				BrickCollision(col);
				break;
			case "BrickEdgeLD":
				if(speed.x > 0)
					speed.x *= -1f;
				if(speed.y > 0)
					speed.y *= -1f;
				BrickCollision(col);
				break;
			case "BrickEdgeLU":
				if(speed.x > 0)
					speed.x *= -1f;
				if(speed.y < 0)
					speed.y *= -1f;
				BrickCollision(col);
				break;
            case "PlayerBody":
                speed.y *= -1;
                Move();
                break;
            case "PlayerLeftEdge":
                speed.y *= -1;
                speed.x = -Mathf.Abs(speed.x);
                speed *= 1.1f;
                Move();
                break;
            case "PlayerRightEdge":
                speed.y *= -1;
                speed.x = Mathf.Abs(speed.x);
                speed *= 1.1f;
                Move();
                break;
        }
    }

    void BrickCollision(Collision2D col)
    {
        Move();
        GameManager.score++;
        if (Random.Range(0, 100) < 10)
            Instantiate(Resources.Load("PowerUp") as GameObject, col.transform.position, Quaternion.identity);
        Destroy(col.transform.parent.gameObject);
    }

    public void Launch()
    {
        transform.position = startingPos;
        speed = new Vector2(1, 1);
        if (Random.Range(0, 2) == 1)
            speed.x *= -1;
    }

    void Move()
    {
        transform.position += new Vector3(speed.x, speed.y, 0) * 0.05f;
        if (transform.position.x > 4 || transform.position.x < -4 || transform.position.y > 4 || transform.position.y < -4)
            Launch();
    }

}

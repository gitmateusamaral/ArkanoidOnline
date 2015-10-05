using UnityEngine;
using System.Collections;

public class PlayerMain : MonoBehaviour {

	public bool AI = false;
    private int size = 0;
    public GameObject Big;
    public GameObject Normal;
    public GameObject Small;

    public float width = 0;
    private Vector2 speed;

	private GameObject ball;

	// Use this for initialization
	void Start () {
		ball = GameObject.Find("Ball");
        speed = Vector2.zero;
        Size = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(!AI)
        	speed = new Vector2(2*Input.GetAxis("Horizontal"), 0);
		else
		{
			if(ball.transform.position.x <  transform.position.x)
				speed.x -=.3f;
			else
				speed.x +=.3f;
			if(speed.x > 2f)
				speed.x = 2f;
			if(speed.x < -2f)
				speed.x = -2f;
		}
	}

    void FixedUpdate()
    {
        Move();
    }

    public int Size
    {
        get
        {
            return this.size;
        }
        set
        {
            if (Small != null)
            {
                Small.transform.Find("LeftEdge").GetComponent<Collider2D>().enabled = value == -1;
                Small.transform.Find("RightEdge").GetComponent<Collider2D>().enabled = value == -1;
                Small.transform.Find("Body").GetComponent<Collider2D>().enabled = value == -1;
                Small.GetComponent<SpriteRenderer>().enabled = value == -1;
                if (value == -1)
                    width = .4f;
            }
            if (Normal != null)
            {
                Normal.transform.Find("LeftEdge").GetComponent<Collider2D>().enabled = value == 0;
                Normal.transform.Find("RightEdge").GetComponent<Collider2D>().enabled = value == 0;
                Normal.transform.Find("Body").GetComponent<Collider2D>().enabled = value == 0;
                Normal.GetComponent<SpriteRenderer>().enabled = value == 0;
                if (value == 0)
                    width = .8f;
            }
            if (Big != null)
            {
                Big.transform.Find("LeftEdge").GetComponent<Collider2D>().enabled = value == 1;
                Big.transform.Find("RightEdge").GetComponent<Collider2D>().enabled = value == 1;
                Big.transform.Find("Body").GetComponent<Collider2D>().enabled = value == 1;
                Big.GetComponent<SpriteRenderer>().enabled = value == 1;
                if (value == 1)
                    width = 1.2f;
            }
            this.size = value;
        }
    }

    void Move()
    {
        transform.position += new Vector3(speed.x, speed.y, 0) * 0.05f;
        if (transform.position.x - width / 2 < -4)
            transform.position = new Vector2(-4 + width / 2, transform.position.y);
        else if (transform.position.x + width / 2 > 4)
            transform.position = new Vector2(4 - width / 2, transform.position.y);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ball : MonoBehaviour {

    public float speed = 15;

    private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
        //Update();
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.right * speed;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        // right or left paddle
        if((collision.gameObject.name=="RightPaddle")||(collision.gameObject.name=="LeftPaddle"))
        {
            ballHitPaddle(collision);
            SoundManagerScript.Instance.PlayOneShot(SoundManagerScript.Instance.Jump);
        }
        // right vertwall or left vertwall
        if ((collision.gameObject.name == "LeftVertWall") || (collision.gameObject.name == "RightVertWall"))
        {
            SoundManagerScript.Instance.PlayOneShot(SoundManagerScript.Instance.goal);

            float y = ballHitPaddleWhere(transform.position,
                collision.transform.position,
                collision.collider.bounds.size.y);
            Vector2 dir = new Vector2();
         if(collision.gameObject.name=="LeftVertWall") {
                dir = new Vector2(1,y).normalized;
                UpdateUIScore("RightPaddleUI");
         }
         if(collision.gameObject.name=="RightVertWall")
            {
                dir = new Vector2(-1,y).normalized;
                UpdateUIScore("LeftPaddleUI");
            }
            rigidBody.velocity = dir * speed;
        }

        // up or bottom
        if ((collision.gameObject.name == "HorzWallUp") || (collision.gameObject.name == "HorzWallDown"))
        {
            SoundManagerScript.Instance.PlayOneShot(SoundManagerScript.Instance.Jump);
            
            float x = ballHitHorzWallWhere(transform.position,
                collision.transform.position,
                collision.collider.bounds.size.x);
            /*
            float y = ballHitPaddleWhere(transform.position,
                collision.transform.position,
                collision.collider.bounds.size.y);
             */
            Vector2 dir = new Vector2();
            if(collision.gameObject.name=="HorzWallUp")
            {
                dir = new Vector2(x, -1).normalized;
            }
            if(collision.gameObject.name=="HorzWallDown")
            {
                dir = new Vector2(x, 1).normalized;
            }
            rigidBody.velocity = dir * speed;
        }
    }

    void ballHitPaddle(Collision2D col)
    {
        float y = ballHitPaddleWhere(transform.position,
            col.transform.position,
            col.collider.bounds.size.y);

        Vector2 dir = new Vector2();

        if(col.gameObject.name=="LeftPaddle")
        {
            dir = new Vector2(1, y).normalized;
        }
        if (col.gameObject.name == "RightPaddle")
        {
            dir = new Vector2(-1, y).normalized;
        }
        rigidBody.velocity = dir * speed; 
    }
        
        
    // where ball hit paddle
    float ballHitPaddleWhere(Vector2 ball,Vector2 paddle,float paddleHeight)
    {
        return (ball.y - paddle.y) / paddleHeight;
    }
    // where ball hit Horizontal wall
    float ballHitHorzWallWhere(Vector2 ball,Vector2 collided,float paddleHeight)
    {
        return (collided.x - ball.x);
    }
    void UpdateUIScore(string textUIName)
    {
        var TextUIComp = GameObject.Find(textUIName).GetComponent<Text>();
        int score = int.Parse(TextUIComp.text);
        score++;
        TextUIComp.text = score.ToString();
    }
    void Update()
    {
        string x = ret("Timer");
        //System.DateTime moment = new System.DateTime();
        var TextUI = GameObject.Find("Timer").GetComponent<Text>();
        float timeleft = int.Parse(TextUI.text);
        if(timeleft>0)
        {
            timeleft = Time.fixedTime;
        }
        TextUI.text = timeleft.ToString();
    }
    string ret(string obj)
    {
        return obj;
    }

}

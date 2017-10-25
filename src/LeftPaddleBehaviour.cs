using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPaddleBehaviour : MonoBehaviour {

    float speed = 20;

    void FixedUpdate()
    {
       float vertPress = Input.GetAxisRaw("Vertical");
        GetComponent<Rigidbody2D>().velocity = new Vector2(0 ,vertPress)*speed;
    }

    // Use this for initialization
    void Start () {
		
	}
	

}

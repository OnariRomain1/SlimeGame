using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireBall : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 50;
    Rigidbody2D rb;
    float timeCount = 0.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = Vector2.right * speed *Time.fixedDeltaTime;
        if (transform.position.x > 10){
            Destroy(gameObject);
        }
        
        //transform.rotation = Quaternion.Lerp(new Quaternion(0,0,0,1), new Quaternion(0,0,360,1), timeCount * lerpSpeed);
       // Quaternion quaternion = Quaternion.Euler(0,0,360);
       // for (int i =0; i < 360; i++){}
}   

void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.gameObject.tag == "Enemy"){
            Destroy(gameObject);
            Destroy(col.gameObject);
            Debug.Log("collided");
        }
        
    }

    
}

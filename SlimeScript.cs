using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class SlimeScript : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;

    Animator animator;
    [SerializeField]
    float speed;
    [SerializeField]
    int DeathCount;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        speed = 30f;
    }

    bool TryMove(){
        rb.velocity = Vector2.left * speed *Time.fixedDeltaTime;
        if (rb.velocity.x !=0 ){
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
      if (TryMove()){
        animator.SetBool("IsMoving",true);
      }
    }

    public void IncreaseSlimeSpeed(float Speed){
        speed = speed + Speed;
        Debug.Log("Speed " + speed);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.gameObject.tag == "Player"){
            //col.gameObject.GetComponent<>
            col.gameObject.GetComponentInChildren<HealthComponentScript>().TakeDamage(1);
            Debug.Log(col.gameObject.GetComponentInChildren<HealthComponentScript>().getHealth());
            Destroy(gameObject);
        }else if (col.collider.gameObject.tag == "Spell"){
            Spawner s =  GetComponentInParent<Spawner>();
            if (s != null){
            s.UE.Invoke();
            }
        } 
        
        
    }

    

}

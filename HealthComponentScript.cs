using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthComponentScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] float maxHealth;
    
    [SerializeField] float currentHealth;
    [SerializeField] GameObject healthText;
    Text textHealth;
    string Healthstatus;
    public void Awake(){
        healthText = GetComponent<GameObject>();
         if (healthText != null){
            textHealth = healthText.GetComponent<Text>();
            Healthstatus = "X " + maxHealth;
            textHealth.text = Healthstatus;
        }
    }
    public void Start(){
        
        currentHealth = maxHealth;
       
       
    }
    private void OnEnable(){
        //HealthChanged.Invoke();
    }

    public void setHealth(float health){
        maxHealth = health;
        currentHealth = maxHealth;
        textHealth.text = Healthstatus;
    }

    public float getHealth(){
        return currentHealth;
    }
     
       public float getMaxHealth(){
        return maxHealth;
    }
     
   public float TakeDamage(float damage){
        
        currentHealth -=damage;
        Debug.Log("Current Health is Now: " + currentHealth);
        return currentHealth;
    }
    
    public bool HealthChanged(){
        if (currentHealth != maxHealth){
            return true;
        }
        return false;
    }
    public string HealthDisplay(){
        return "X " + currentHealth;
    }
    void Update(){
        
        if (currentHealth != maxHealth){
            if (textHealth != null ){
           textHealth.text = Healthstatus;
            }
        } 
       
    

   
    }

 
}

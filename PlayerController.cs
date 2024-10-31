using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    
    List<KeyCode> Inputs;
    [SerializeField]
    int numOfInputs = 3;
    string key = "";
    char []characters;
    public GameObject TextHandler;
    public GameObject HealthUI;
    private Text text;
    private Text htext;
    public GameObject h;
    private Animator animator;
    public GameObject []spell;
    [SerializeField]
    
    HealthComponentScript healthS;
    Vector2 spellSpawnPoint = new Vector2(-6.15f, -0.6f);

    private Text HealthText;


    int count = 0;
    int NumOfTImesReset = 0;
    // Start is called before the first frame update
    void Start()
    {
    
      //Debug.Log(GenerateAlphabet());
      healthS = GetComponentInChildren<HealthComponentScript>();
     
      Debug.Log(healthS.getHealth());
      htext = h.GetComponent<Text>();

      

      text = TextHandler.GetComponent<Text>();
      htext.text = "X " + healthS.getHealth();
      
      animator = GetComponent<Animator>();

      Inputs = RandomInput(numOfInputs);
      Debug.Log("TYPE THESE CHARACTERS TO SHOOT");
      key = DisplayInputs(Inputs);
      text.text = key;
      
      Debug.Log(key);

    }

    // Update is called once per frame
    void Update()
    {
     if (!IsDead()){   
        if (Input.GetKeyUp(Inputs.First())){
          UpdateInputs(Inputs);
        }
        if (count == numOfInputs){
          Debug.Log("FIRE");
          animator.SetTrigger("Attack");
          spawnSpell(RandomSpell());
          ResetInputs();
        }
       
       // HealthChanged();
     }
       if (healthS.HealthChanged()){
          htext.text = healthS.HealthDisplay();
        }
        

        
    }

    void UpdateInputs(List<KeyCode> inputs){
       Debug.Log(Inputs.First() +"Pressed");
          Inputs.RemoveAt(0);
          Debug.Log(Inputs.First());
          string current = DisplayInputs(Inputs);
          text.text = "";
          text.text = current;
          count++;

    }

    void spawnSpell(GameObject spell){
      Instantiate(spell, spellSpawnPoint, spell.transform.rotation);
    }
    GameObject RandomSpell(){
        int SpellIndex = Random.Range(0,spell.Length);
        return spell[SpellIndex];
    }

    void ResetInputs(){
      count =0;
      Inputs.Clear();
      Inputs = RandomInput(numOfInputs);
      Debug.Log("TYPE THESE CHARACTERS TO SHOOT");
      key = DisplayInputs(Inputs);
      text.text = key;
      //animator.SetBool("Attack",false);
    }

    string DisplayInputs(List<KeyCode> inputs){
      string InputsBuilder = "";
      Inputs.ForEach(x =>{
        if (x.ToString() != KeyCode.End.ToString()){
          InputsBuilder += x.ToString();
        }

      } );
      return InputsBuilder;
    }

    //Want to be able to return a random string of characters which will be what the character needs to type in order to use magic
    List<KeyCode> RandomInput(int numOfInputs){
     
      KeyCode tempcharacters;
      List<KeyCode> inputs = new List<KeyCode>();
      for (int i =0; i < numOfInputs; i++){
        tempcharacters = (KeyCode)(((int)KeyCode.A) + Random.Range(0,26));
        inputs.Add(tempcharacters);
        //Debug.Log(tempcharacters);
      }
      inputs.Add(KeyCode.End);
      return inputs;
       
      }

      void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.gameObject.tag == "Enemy"){
            //col.gameObject.GetComponent<>
            Debug.Log("Current Health is now: " + healthS.getHealth());
            Destroy(col.gameObject);
        }
        
    }
    bool IsDead(){
      if (healthS.getHealth() <= 0){
        animator.SetTrigger("Death");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        return true;
      }
      return false;
    }

    void HealthChanged(){
      float currentHealth = healthS.getHealth();
      if (currentHealth != healthS.getHealth()){
        Debug.Log("HealthChanged");
      }
    }
    public void OnDeathAnimationFinished(){
      Destroy(gameObject);
    }
    
     
    
    }


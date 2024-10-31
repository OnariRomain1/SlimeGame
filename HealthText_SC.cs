using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class HealthText_SC : MonoBehaviour
{
    Text text;
    [SerializeField] private string Text;
    public HealthComponentScript healthComponent;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        healthComponent = healthComponent.GetComponent<HealthComponentScript>();
        Text = healthComponent.HealthDisplay();
        text.text = Text;

    }

    // Update is called once per frame
     void Update()
    {

    }

    public void ChangeHealthDisplay(){
        
        Text = healthComponent.HealthDisplay();
    }
}

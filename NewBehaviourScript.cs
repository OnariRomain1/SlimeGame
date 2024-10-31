using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]  UnityEvent increaseScoreEvent;
    public int score;
    public string ScoreText;
    [SerializeField] Text Text;

    void Awake(){
        score = 0;
        ScoreText = "";
    }
    public void setScore(int score){
        this.score = score;
    }
    public void increaseScore(int scoreInc){
        score += scoreInc;
    }

    public int getScore(){
        return score;
    }

    public void SetScoreText(string ScoreText){
        this.ScoreText = ScoreText;
    }

    public void setTextDisplay(){
        ScoreText = "Score: " + score;
        Text.text = ScoreText;
    }

    void Update(){
       
            setTextDisplay();
    }
}

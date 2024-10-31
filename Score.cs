using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    private int score;
    private string ScoreText;
    [SerializeField] Text Text;

    void setScore(int score){
        this.score = score;
    }
    void increaseScore(int scoreInc){
        score += scoreInc;
    }

    int getScore(){
        return score;
    }

    void SetScoreText(string ScoreText){
        this.ScoreText = ScoreText;
    }

    void setTextDisplay(){
        Text.text = ScoreText;
    }
}

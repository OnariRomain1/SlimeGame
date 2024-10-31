using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;
public class Spawner : MonoBehaviour
{   
    [SerializeField]
    GameObject []Enemies;
    [SerializeField]
    Vector2 SpawnLocation;
    [SerializeField] float SpawnTime;
    [SerializeField] public UnityEvent UE;
    int DeathCount;
    float sTime = 4 ;

    // Start is called before the first frame update
    void Start()
    { 
        DeathCount = 0;
        ResetDeathCount();
       SpawnEnemy(RandomEnemy());
    }

    void Update(){
        if (SpawnTime > 0){
            SpawnTime -= Time.deltaTime;
        } else if (SpawnTime < 0){
            SpawnTime = 0;
            SpawnEnemy(RandomEnemy());
        }

        if (SpawnTime == 0){
            if (DeathCount >2){
                SetSpawnTime(sTime -.5f);
                
            } else {
                SetSpawnTime(sTime);
            }
            ResetDeathCount();
        }
      //  Debug.Log(SpawnTime);
    }
    // Update is called once per frame

    void FixedUpdate()
    {
        //figure out a way to make it not be spamed 
     
    }

    void SpawnEnemy(GameObject gameObject){
        
       var obj = Instantiate(gameObject,SpawnLocation,gameObject.transform.rotation);
        obj.transform.parent = transform;
       
       
    }

    GameObject RandomEnemy(){
        int EnemyIndex = Random.Range(0,Enemies.Length);
        return Enemies[EnemyIndex];
    }

    void SetSpawnTime(float Time){
        SpawnTime = Time;
        
    }

    bool IncreaseSpawnRate(){
        if (DeathCount >5 ){
            SpawnTime--;
            ResetDeathCount();
            return true;
        }
        return false;
    }

    public void IncreaseDeathCount(){

        DeathCount++;
        Debug.Log(DeathCount);
    }
    void ResetDeathCount(){
        DeathCount = 0;
    }
}

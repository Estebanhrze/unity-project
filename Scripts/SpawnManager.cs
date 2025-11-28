using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour{
    public GameObject[] itemPrefab; 

    public float minTime = 1f;
    public float maxTime = 2f;

    void Start(){ 
        StartCoroutine(SpawnCoRuntine(Random.Range(minTime, maxTime))); 
    }
    
    IEnumerator SpawnCoRuntine(float waitTime){
        yield return new WaitForSeconds(waitTime);
        Instantiate(itemPrefab[Random.Range(0,itemPrefab.Length)],
        transform.position,Quaternion.identity);
        StartCoroutine(SpawnCoRuntine(Random.Range(minTime,maxTime)));
    }
}   
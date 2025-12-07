using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageController : MonoBehaviour{
    void OnTriggerEnter2D(Collider2D collision){
        
        if(collision.gameObject.CompareTag("Platform")){
            Destroy(collision.gameObject);
        }
    }
}
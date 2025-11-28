using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2D : MonoBehaviour{
    public Transform targetPlayer;
    

    void Start(){

    }

    void Update(){
        transform.position = new Vector3(targetPlayer.position.x + 6f,0,-10);
    }
}
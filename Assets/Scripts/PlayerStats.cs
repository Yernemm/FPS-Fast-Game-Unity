using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    private int health;

    private void Start() {
        health = 100;
    }

    private void Update() {
        if(transform.position.y <= 0 && !this.isDead()){
            this.damage(this.getHealth());
        }
    }

    public bool damage(int hp){
        health -= hp;
        if(health <= 0){
            return true;
        } else {
            return false;
        }
    }

    public int getHealth(){
        return health;
    }

    public bool isDead(){
        return health <= 0;
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private State stateEnemy;
    public void changState(State newState){
        if(stateEnemy!=null){
            stateEnemy.OnExit();
        }
        stateEnemy = newState;
        if(stateEnemy!=null){
            stateEnemy.OnExit();
        }
    }
    private void OnEnable() {
        
    }
    private void Start() {
        eCharacter = ECharacter.Enemy;
    }
    private void OnDead(){
        QueueEnemy.Instance.addEnemy(this);
    }
}

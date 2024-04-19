using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private State stateEnemy;
    
    private void OnEnable() {
        changState(new StateMove(this));
    }
    private void Start() {
        eCharacter = ECharacter.Enemy;
    }
    private void Update() {
        if(stateEnemy!=null) stateEnemy.OnExecute();
    }
    public void changState(State newState){
        if(stateEnemy!=null){
            stateEnemy.OnExit();
        }
        stateEnemy = newState;
        if(stateEnemy!=null){
            stateEnemy.OnExit();
        }
    }
    public void MoveToPlayer(){

    }
    private void OnDead(){
        QueueEnemy.Instance.addEnemy(this);
    }
}

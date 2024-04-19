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
        if(Heart<=0) OnDead();
    }
    public void changState(State newState){
        stateEnemy?.OnExit();
        stateEnemy = newState;
        stateEnemy?.OnEnter();
    }
    public void MoveToPlayer(){

    }
    public void GetDame(float dame){
        Heart -= dame;
    }
    private void OnDead(){
        QueueEnemy.Instance.addEnemy(this);
    }
}

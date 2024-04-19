using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private GameObject player;
    private State stateEnemy;
    
    private void OnEnable() {
        changState(new StateMove(this));
    }
    private void Start() {
        player = FindObjectOfType<Player>().gameObject;
        GameController.Instance.SetDataCharacter(this);
        eCharacter = ECharacter.Enemy;
        changState(new StateMove(this));
    }
    private void Update() {
        if(stateEnemy!=null) stateEnemy.OnExecute();
        if(Heart<=0) OnDead();
        if(checkPlayer()) changState(new StateAttack(this));
        else changState(new StateMove(this));
    }
    public void changState(State newState){
        stateEnemy?.OnExit();
        stateEnemy = newState;
        stateEnemy?.OnEnter();
    }
    public void MoveToPlayer(){
        Vector3 target = new Vector3(player.transform.position.x, transform.position.y,0);
        transform.position = Vector3.MoveTowards(transform.position, target,Time.deltaTime);
    }
    public void AttackPlayer(){
        Debug.Log("Attack Player");
    }
    private bool checkPlayer(){
        Vector2 direction = player.transform.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1.2f,LayerMask.GetMask("Player"));
        return hit.collider != null;
    }
    public void GetDame(float dame){
        Heart -= dame;
    }
    private void OnDead(){
        QueueEnemy.Instance.addEnemy(this);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private GameObject player;
    private State stateEnemy;
    public EDirec eDirec { get; set; }
    public bool okGetDame { get; set; }
    private void OnEnable()
    {
        okGetDame = true;
        changState(new StateMove(this));
    }
    private void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
        GameController.Instance.SetDataCharacter(this);
        eCharacter = ECharacter.Enemy;
        changState(new StateMove(this));
        okGetDame = true;
    }
    private void Update()
    {
        if (stateEnemy != null) stateEnemy.OnExecute();
        if (Heart <= 0) OnDead();
        if (checkPlayer()) changState(new StateAttack(this));
        else changState(new StateMove(this));
    }
    public void changState(State newState)
    {
        stateEnemy?.OnExit();
        stateEnemy = newState;
        stateEnemy?.OnEnter();
    }
    public void MoveToPlayer()
    {
        Vector3 target = new Vector3(player.transform.position.x, transform.position.y, 0);
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime);
    }
    public void AttackPlayer()
    {
        Debug.Log("Attack Player");
    }
    private bool checkPlayer()
    {
        Collider2D check = Physics2D.OverlapCircle(transform.position, 1, LayerMask.GetMask("Player"));
        return check != null;
    }
    public void GetDame(float dame)
    {
        Heart -= dame;
    }
    private void OnDead()
    {
        QueueEnemy.Instance.addEnemy(this);
    }
}

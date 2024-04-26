using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Character
{
    private GameObject player;
    private State stateEnemy;
    public EDirec eDirec { get; set; }
    public bool okGetDame { get; set; }
    [SerializeField] private GameObject spriteAnim;
    private Animator anim;
    [SerializeField] private Slider sliderHeart;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        OnInit();
    }
    private void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
        GameController.Instance.SetDataCharacter(this);
        eCharacter = ECharacter.Enemy;
        OnInit();
    }
    private void OnInit()
    {
        okGetDame = true;
        changState(new StateMove(this));
        sliderHeart.maxValue = Heart;
    }
    private void Update()
    {
        this.sliderHeart.value = Heart;
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
    float timeAttack;
    public void AttackPlayer()
    {
        if (timeAttack < 5)
        {
            timeAttack = 0;
            player.GetComponent<Player>().Heart -= Dame;
        }
        else
            timeAttack += Time.deltaTime;
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

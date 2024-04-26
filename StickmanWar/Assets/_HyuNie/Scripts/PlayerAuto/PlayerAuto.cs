using UnityEngine;

public class PlayerAuto : Character
{
    private IState state;
    public GameObject enemy { get; set; }
    public Transform target { get; set; }
    private void Update()
    {
        if (enemy)
        {
            Debug.DrawLine(transform.position, enemy.transform.position, Color.gray);
            MoveToEnemy();
        }

        state?.OnExecute(this);
        if (enemy == null || !enemy.activeSelf)
        {
            changeState(new PLStateIdle());
        }
        else
        {
            changeState(new PLStateAttack());
        }
    }
    public void changeState(IState newState)
    {
        state?.OnExit(this);
        state = newState;
        state?.OnEnter(this);
    }
    public bool checkEnemy()
    {
        Debug.DrawLine(transform.position, transform.position + (transform.position - enemy.transform.position).normalized * 2, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.position - enemy.transform.position, 2, LayerMask.GetMask("Enemy"));
        return hit.collider != null;
    }
    public GameObject findEnemy()
    {
        return EnemySystem.Instance.getTargetEnemy();
    }
    public void MoveToEnemy()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, 0.5f);
    }
    public void setTargetToEnemy()
    {
        target.position = enemy.transform.position;
    }
    private float timeAttack = 0;
    public void AttackEnemy()
    {
        Debug.Log("Attack Enemy");
        if (timeAttack < 2)
        {
            timeAttack += Time.deltaTime;
        }
        else
        {
            enemy.GetComponent<Enemy>().Heart -= Dame;
            Debug.Log(enemy.GetComponent<Enemy>().Heart);
            timeAttack = 0;
        }
    }
}
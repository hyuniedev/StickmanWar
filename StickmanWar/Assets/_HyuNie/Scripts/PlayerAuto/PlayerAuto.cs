using UnityEngine;

public class PlayerAuto : Character
{
    private IState state;
    public GameObject enemy { get; set; }
    private void Update()
    {
        if (enemy)
            Debug.DrawLine(transform.position, enemy.transform.position, Color.gray);
        state?.OnExecute(this);
        if (enemy == null)
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
    public GameObject findEnemy()
    {
        return EnemySystem.Instance.getTargetEnemy();
    }
}
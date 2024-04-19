public class StateAttack : State{
    public StateAttack(Enemy enemy) : base(enemy) { }
    public override void OnExecute(){
        _enemy.AttackPlayer();
    }
}
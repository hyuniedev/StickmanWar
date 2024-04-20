public class StateMove : State{
    public StateMove(Enemy enemy) : base(enemy) { }
    public override void OnExecute(){
        _enemy.MoveToPlayer();
    }
}
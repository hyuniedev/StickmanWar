using UnityEngine;

public class EventButton: MonoBehaviour {
    [SerializeField] private Player player;
    public void buttonMove_Left(){
        if(Look.isLook){
            player.moveToEnemy();
        }else{
            player.move(-3f);
        }
    }
    public void buttonMove_Right(){
        if(Look.isLook){
            player.moveToEnemy();
        }else{
            player.move(3f);
        }
    }
}
using UnityEngine;

public class EventButton: MonoBehaviour {
    [SerializeField] private Player player;
    public void buttonMove_Left(){
        player.move();
    }
    public void buttonMove_Right(){

    }
}
using UnityEngine;

public class EventButton: MonoBehaviour {
    [SerializeField] private Player player;
    public void buttonMove_Left(){
        player.move(-3f);
    }
    public void buttonMove_Right(){
        player.move(3f);
    }
}
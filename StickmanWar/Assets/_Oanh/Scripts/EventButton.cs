using UnityEngine;

public class EventButton: MonoBehaviour {
    [SerializeField] private Player player;
    [SerializeField] private Table table;
    private bool isOn=false;
    public Look lookRange;
    public void buttonMove_Left(){
        lookRange.transform.position = new Vector3(player.transform.position.x -3f, player.transform.position.y, player.transform.position.z);
        if(Look.isLook){
            player.moveToEnemy();
            Look.isLook = false;
        }else{
            player.move(-2f);

        }
    }
    public void buttonMove_Right(){
        lookRange.transform.position = new Vector3(player.transform.position.x +3f, player.transform.position.y, player.transform.position.z);
        if(Look.isLook){
            player.moveToEnemy();
            Look.isLook=false;
        }else{
            player.move(2f);
        }   
        
    }
    public void buttonOnTable(){
        table.gameObject.SetActive(!table.gameObject.activeSelf);
    }
}
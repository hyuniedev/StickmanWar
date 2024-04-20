using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Character
{   
    private Vector3 targetPosition;
    
    public Enemy enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        eCharacter = ECharacter.Player;
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if(Look.isLook){
            
            transform.position = Vector3.MoveTowards(transform.position,targetPosition,Time.deltaTime*10f);
        }else{
            transform.position = Vector3.MoveTowards(transform.position,targetPosition,Time.deltaTime*5f);
        }
        
    }
    public void move(float x){
        targetPosition = new Vector3(transform.position.x + x, transform.position.y , 0);
    }
    
    public void moveToEnemy(){
        targetPosition = enemy.transform.position;
    }

    
    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag.Equals("Enemy")){
            Debug.Log("Oanh cham roi");
            targetPosition = transform.position;
            
        }
    }
    
}

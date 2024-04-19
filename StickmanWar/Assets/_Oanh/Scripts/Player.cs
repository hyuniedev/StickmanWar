using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] Transform target;
    // Start is called before the first frame update
    void Start()
    {
        eCharacter = ECharacter.Player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void move(){
        Vector3 direction= Vector3.MoveTowards(transform.position,target.position,Time.deltaTime);
    }
}

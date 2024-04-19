using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private Vector3 offset = new Vector3(3,0,0);
    public void nakika(){
        transform.position = Vector3.Lerp(transform.position, transform.position + offset, Time.deltaTime);
    }
}

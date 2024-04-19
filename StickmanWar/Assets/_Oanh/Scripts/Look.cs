using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Look : MonoBehaviour
{
    
    public static Look instance;
    public static bool isLook=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isLook);
    }
    public void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag.Equals("Enemy")){
            Debug.Log("DD");
            isLook=true;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTable(){
        if(anim.GetInteger("IsOn")==0){
            anim.SetInteger("IsOn",1);
        }else if(anim.GetInteger("IsOn")==1){
            anim.SetInteger("IsOn",2);
        }else if(anim.GetInteger("IsOn")==2){
            anim.SetInteger("IsOn",3);
        }else{
            anim.SetInteger("IsOn",2);
        }
    }
}

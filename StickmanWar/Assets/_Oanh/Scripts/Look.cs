using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Look : MonoBehaviour
{

    public static Look instance;
    public static bool isLook = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            isLook = true;
            // Debug.Log("mi");
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Co va cham");
        if (other.gameObject.tag.Equals("Enemy"))
        {
            Debug.Log("Collider look with Enemy");
        }
    }
}

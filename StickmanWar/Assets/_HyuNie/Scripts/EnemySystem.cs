using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
public class EnemySystem : MonoBehaviour {
    [Header("Prefab Enemy")]
    [SerializeField] private GameObject enemyPref;
    [Header("2 vi tri sinh enemy")]
    [SerializeField] private Transform[] transforms_PornEnemy;
    [Header("Ymin/Ymax")]
    [SerializeField] private float yMax;
    [SerializeField] private float yMin;
    [Header("Thoi gian sinh enemy")]
    [SerializeField] private float timeInstanceEnemy;
    private void Start() {
        InvokeRepeating(nameof(BornEnemy),2,3);
    }
    private void BornEnemy(){
        Vector3 posBorn = new Vector3(transforms_PornEnemy[Random.Range(0,2)].position.x,Random.Range(yMin,yMax),0);
        Enemy tmpEnemy = QueueEnemy.Instance.getEnemy();
        if(tmpEnemy != null){
            tmpEnemy.transform.position = posBorn;
        }else{
            Instantiate(enemyPref,posBorn,transform.rotation,this.transform).SetActive(true);
        }
    }
}
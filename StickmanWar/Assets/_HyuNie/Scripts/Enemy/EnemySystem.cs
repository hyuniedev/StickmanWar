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
    private static EnemySystem instance;
    public static EnemySystem Instance {
        get {
            return instance;
        }
    }
    [SerializeField] private GameObject player;
    private void Awake() {
        instance = this;
    }
    private void Start() {
        InvokeRepeating(nameof(BornEnemy),2,3);
    }
    private void BornEnemy(){
        int ranX = Random.Range(0,2);
        Vector3 posBorn = new Vector3(transforms_PornEnemy[ranX].position.x,Random.Range(yMin,yMax),0);
        Enemy tmpEnemy = QueueEnemy.Instance.getEnemy();
        if(tmpEnemy != null){
            tmpEnemy.transform.position = posBorn;
            tmpEnemy.eDirec = ranX==0?EDirec.Left:EDirec.Right;
        }else{
            GameObject gob = Instantiate(enemyPref,posBorn,transform.rotation,this.transform);
            gob.SetActive(true);
            gob.GetComponent<Enemy>().eDirec = ranX==0?EDirec.Left:EDirec.Right;
        }
    }
    public GameObject getTargetEnemy(EDirec eDirec) {
        float min = 1000;
        Enemy tmp = new Enemy();
        bool haveEnemyTarget = false;
        Enemy[] enemies = FindObjectsOfType<Enemy>(false);
        foreach (var o in enemies)
        {
            if(o.eDirec==eDirec&&min>Vector3.Distance(Vector3.zero,o.gameObject.transform.position)){
                min = Vector3.Distance(Vector3.zero,o.gameObject.transform.position);
                tmp = o;
                haveEnemyTarget = true;
            }
        }
        return haveEnemyTarget?tmp.gameObject:null;
    }
    private Enemy tmp;
    public GameObject getTargetEnemy() {
        float min = 1000;
        bool haveEnemyTarget = false;
        Enemy[] enemies = FindObjectsOfType<Enemy>(false);
        foreach (var o in enemies)
        {
            if(min>Vector3.Distance(player.transform.position,o.gameObject.transform.position)){
                min = Vector3.Distance(player.transform.position,o.gameObject.transform.position);
                tmp = o;
                haveEnemyTarget = true;
            }
        }
        return haveEnemyTarget?tmp.gameObject:null;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueEnemy{
    private static QueueEnemy instance;
    public static QueueEnemy Instance{
        get{
            if(instance == null){
                instance = new QueueEnemy();
            }
            return instance;
        }
    }
    private Queue<Enemy> enemyQueue = new Queue<Enemy>();
    public void addEnemy(Enemy enemy){
        enemyQueue.Enqueue(enemy);
    }
    public Enemy getEnemy(){
        return enemyQueue.Dequeue();
    }
}
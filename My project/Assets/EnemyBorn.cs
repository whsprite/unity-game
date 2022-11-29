using UnityEngine;

public class EnemyBorn : MonoBehaviour
{
    private float x_min = 240;
    private float x_max = 390;
    private float y_min = 130;
    private float y_max = 210;
    public GameObject enemyPrefab_1;
    public GameObject enemyPrefab_2;
    public static int enemy_num = 0;
    private Transform enemyPosition;
    private float t1;
    private float t2;
    private int p;

    void Start()
    {
        enemyPosition = transform.Find("EnemyPosition");
        t2 = Time.fixedTime;
        t1 = t2 + 1;
    }

    void Update()
    {
        t1 = Time.fixedTime;

        if (enemy_num < 3 && t1 - t2 >= 3)
        {
            print(enemyPosition.position);
            print(enemyPosition.localPosition);
            Vector3 pos = enemyPosition.position;
            pos.x = Random.Range(x_min, x_max);
            pos.y = -59.7f;
            pos.z = Random.Range(y_min, y_max);
            enemyPosition.position = pos;
            p = Random.Range(0, 10);
            if(p >= 2)
            {
                GameObject enemyInstance = GameObject.Instantiate(enemyPrefab_1, enemyPosition.position, enemyPosition.rotation);
            } else
            {
                GameObject enemyInstance = GameObject.Instantiate(enemyPrefab_2, enemyPosition.position, enemyPosition.rotation);
            }
            
            enemy_num += 1;
            t2 = Time.fixedTime;
        }
        
    }

    public static void Kill()
    {
        enemy_num -= 1;
    }
}

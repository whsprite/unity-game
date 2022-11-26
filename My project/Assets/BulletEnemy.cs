using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

        //Destroy(this.gameObject, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Enemy" && other.tag != "EnemyBullet") {
            Destroy(this.gameObject);
        }
            
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float t1;
    private float t2;
    private int check;

    // Start is called before the first frame update
    void Start()
    {
        t1 = Time.fixedTime;
        check = 0;
        //Destroy(this.gameObject, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        t2 = Time.fixedTime;
        if(t2 - t1 >= 0.2 && check == 0)
        {
            this.gameObject.AddComponent<SphereCollider>();
            check = 1;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}

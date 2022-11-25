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

        //Destroy(this.gameObject, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}

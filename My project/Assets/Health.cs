using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float CurrentHealth = 80.0f;
    public float HealthContainer = 100.0f;
    public Image HealthImage;
    private float t1;
    private float t2;

    // Start is called before the first frame update
    void Start()
    {
        
        t2 = Time.fixedTime;
        t1 = t2 + 1;
    }

    // Update is called once per frame
    void Update()
    {
        t1 = Time.fixedTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "EnemyBullet" && t1 - t2 >= 1)
        {
            Harm();
            t2 = Time.fixedTime;
        }
    }
        
    public void Harm()
    {
        CurrentHealth -= 5;
        Amount();

    }
    public void Amount()
    {
        HealthImage.fillAmount = CurrentHealth / HealthContainer;
    }
}

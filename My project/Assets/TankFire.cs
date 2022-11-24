using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankFire : MonoBehaviour
{
    //炮弹物体，再untiy面板中赋值
    public GameObject firePrefab;
    //keycode，按下发射炮弹，unity面板中赋值
    public KeyCode mKeyCode;
    //炮弹速度，可在unity面板中赋值
    public float shellSpeed = 10;
    //发射的位置，我们放置的空物体
    private Transform _firePosition;

    private int interval;
    private float t1;
    private float t2;

    // Start is called before the first frame update
    void Start()
    {
        //得到防止的空物体的位置
        _firePosition = transform.Find("FirePosition");
        t1 = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {
        t2 = Time.fixedTime;
        //如果按下自定义按键
        if (Input.GetKeyDown(mKeyCode) && t2 - t1 >= 0.5)
        {
            //初始化炮弹实例
            GameObject fireInstance =
                GameObject.Instantiate(firePrefab, _firePosition.position, _firePosition.rotation);
            fireInstance.AddComponent<Bullet>();
            //发射炮弹，给炮弹的刚体组件一个速度和方向
            fireInstance.GetComponent<Rigidbody>().velocity = fireInstance.transform.forward * shellSpeed;
            t1 = Time.fixedTime;
        }
    }
}

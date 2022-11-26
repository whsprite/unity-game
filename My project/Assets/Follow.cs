using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour
{
    public Transform target;
    UnityEngine.AI.NavMeshAgent agent;

    float myCollisionRadius;
    float targetCollisionRadius;

    [Range(1.0f, 100.0f)]
    public float attackDistanceThreshold = 1.0f;

    float nextAttackTime;
    // 1 second.
    float timeBetweenAttacks = 1;
    //炮弹物体，再untiy面板中赋值
    public GameObject firePrefab;
    //炮弹速度，可在unity面板中赋值
    public float shellSpeed = 10;
    //发射的位置，我们放置的空物体
    private Transform _firePosition;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        myCollisionRadius = GetComponent<CapsuleCollider>().radius;
        targetCollisionRadius = target.GetComponent<SphereCollider>().radius;

        StartCoroutine(UpdatePath());

        _firePosition = transform.Find("FirePosition");
    }

    void Update()
    {
        // Time.timeはゲーム開始からの秒。
        if (Time.time > nextAttackTime)
        {

            // 距離を比較するときは、平方根(Mathf.Sqrt)のコストが高いので、距離の二乗通しを計算することで、パフォーマンスをあげる。
            // 現在のターゲットと自身の距離の二乗。
            float sqrMag = (target.position - transform.position).sqrMagnitude;
            // 攻撃開始の閾値の二乗
            float sqrAttackRange = Mathf.Pow(myCollisionRadius + targetCollisionRadius + attackDistanceThreshold, 2);
            if (sqrMag < sqrAttackRange)
            {
                nextAttackTime = Time.time + timeBetweenAttacks;
                //初始化炮弹实例
                GameObject fireInstance =
                    GameObject.Instantiate(firePrefab, _firePosition.position, _firePosition.rotation);
                fireInstance.AddComponent<BulletEnemy>();
                Physics.IgnoreCollision(fireInstance.GetComponent<SphereCollider>(), gameObject.GetComponent<CapsuleCollider>());
                //发射炮弹，给炮弹的刚体组件一个速度和方向
                fireInstance.GetComponent<Rigidbody>().velocity = fireInstance.transform.forward * shellSpeed;
                Debug.Log("Attack");
            }
        }
    }

    IEnumerator UpdatePath()
    {
        while (target != null)
        {
            // ターゲットの中心にまで移動する
            //Vector3 targetPosition = new Vector3(target.position.x, 0f, target.position.z);
            //agent.SetDestination(targetPosition);

            // 方向を求める
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            // directionToTarget * (自分の半径+ターゲットの半径)で、自分とターゲットの半径の長さ分の向きベクトルが求められる。
            // つまり、元々のターゲット座標から、この長さのベクトルを引けば、ターゲットに重ならない。また、マージンとしてattackDistanceThresholdを用意している。
            // これはoffsetでもpaddingでもmarginでもどんな変数でもよくて、とりあえず、敵の攻撃範囲としている。
            Vector3 targetPosition = target.position - directionToTarget * (myCollisionRadius + targetCollisionRadius + attackDistanceThreshold / 2);
            agent.SetDestination(targetPosition);


            // １秒ウェイト
            yield return new WaitForSeconds(.5f);
        }
    }
}
using UnityEngine;

public class Move : MonoBehaviour
{
    private CharacterController cc;
    public float speed = 40;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if (Mathf.Abs(h) > 0.1f || Mathf.Abs(v) > 0.1)
        {
            Vector3 targetDir = new Vector3(h, 0, v);
            transform.LookAt(targetDir + transform.position);
            cc.SimpleMove(transform.forward * speed);
        }
    }
}

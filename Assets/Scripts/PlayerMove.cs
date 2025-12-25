using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    Rigidbody roalRigidbody;
    Vector3 roalMove;
    Quaternion quaternion=Quaternion.identity;
    private float roleRotation = 20f;//旋转速度
    void Start()
    {
        animator=GetComponent<Animator>();
        roalRigidbody=GetComponent<Rigidbody>();
        quaternion = transform.rotation; // 初始化四元数
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");//水平方向
        float vertical = Input.GetAxis("Vertical");//竖直方向

        roalMove.Set(horizontal, 0f, vertical);
        roalMove.Normalize();

        bool hori = !Mathf.Approximately(horizontal, 0f);
        bool vert = !Mathf.Approximately(vertical, 0f);

        bool roalIsMove = hori || vert;

        animator.SetBool("isWalking", roalIsMove);

        if (roalIsMove)
        {
            //三元数转四元数
            //transform.forward当前对象方向
            //roalMove待转方向
            //roleRotation * Time.deltaTime转向速度
            Vector3 rotateTowards = Vector3.RotateTowards(transform.forward, roalMove, roleRotation * Time.deltaTime, 0f);
            
            quaternion = Quaternion.LookRotation(rotateTowards);
            quaternion.Normalize(); // 确保四元数是单位长度
        }
    }

    public void OnAnimatorMove()
    {
        if (roalRigidbody != null)
        {
            roalRigidbody.MoveRotation(quaternion);
            float moveSpeed = 1.0f;
            roalRigidbody.MovePosition(roalRigidbody.position + roalMove * moveSpeed * Time.deltaTime);
            //roalRigidbody.MovePosition(roalRigidbody.position + roalMove * animator.deltaPosition.normalized);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{

    private NavMeshAgent navMeshAgent;
    public Transform[] setPosition;//存储定点巡航位置
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();//获取导航组件
        navMeshAgent.SetDestination(setPosition[0].position);
    }

    // Update is called once per frame
    int index = 0;
    void Update()
    {
        //.remainingDistance到达目标位置停止前的距离//路径有效才会返回距离
        //stoppingDistance可动态设置参数，到达目标位置立即停止，参数为1，则距离1m时立即停止
        //.pathPending判断路径是否还在计算中
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.pathPending)
        {
            index = (index + 1) % setPosition.Length;//防止越界
            navMeshAgent.SetDestination(setPosition[index].position);//设置下一巡航位置
        }
    }
}

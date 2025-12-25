using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gargoyle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameOver gameOver;
    public GameObject player;//ÕÊº“
    private Vector3 rayForward;

    bool isTrigger = false;

    private void OnTriggerEnter(Collider other)//ºÏ≤‚ÕÊº“Ω¯»Î…®√Ë∑∂Œß
    {
        if(other.gameObject==player)
        {
            isTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)//ºÏ≤‚ÕÊº“¿Îø™…®√Ë∑∂Œß
    {
        if(other.gameObject==player)
        {
            isTrigger = false;
        }
    }
   
    void Update()
    {
        if(isTrigger)
        {
            rayForward = player.transform.position - transform.position;

            Ray ray = new Ray(transform.position, rayForward + rayForward.normalized);
            if(Physics.Raycast(ray,out RaycastHit hit))
            {
                if(hit.collider.gameObject==player)
                {
                    //GameOver;Physics.Raycast(ray, out RaycastHit hitInfo)
                    gameOver.GameIsFail();
                }
            }
        }
    }
}

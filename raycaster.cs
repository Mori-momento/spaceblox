using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycaster : MonoBehaviour
{
    bool rayHit = false;
    float collisionStartTime;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.queriesStartInColliders = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!rayHit)
        {
            collisionStartTime = Time.time;
        }
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up);
        if(hitInfo.collider!=null)
        {
            rayHit = true;
            Debug.Log(Time.time - collisionStartTime);
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
            if(Time.time-collisionStartTime>=hitInfo.collider.transform.localScale.x/10f)
            {
                Destroy(hitInfo.collider.gameObject);
            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.up * 10, Color.green);
            rayHit = false;
        }
    }
}

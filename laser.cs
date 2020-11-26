using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    private float speed = 20f;
    private float halfScreenHieght;
   
    void Start()
    {
        halfScreenHieght = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = Vector3.up * speed;
        Vector3 moveAmount = velocity * Time.deltaTime;
        transform.Translate(moveAmount);

        if(transform.position.y>halfScreenHieght+transform.lossyScale.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="obstacle")
        {
            Destroy(gameObject);
        }
    }
}

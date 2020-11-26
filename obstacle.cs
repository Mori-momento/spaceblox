using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    float obstacleSpeed;
    float halfScreenHieght;
    // Start is called before the first frame update
    private void Start()
    {
        halfScreenHieght = Camera.main.orthographicSize;
        obstacleSpeed = Random.Range(10f,15f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = Vector3.down * obstacleSpeed;
        Vector3 moveAmount = velocity * Time.deltaTime;
        transform.Translate(moveAmount, Space.Self);

        if(transform.position.y<-halfScreenHieght-transform.localScale.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="laser")
        {
            Destroy(gameObject);
        }
    }
}

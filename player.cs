using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour

{
    [SerializeField] private float speed;
    float halfScreenWidth;
    float halfScreenHieght;
    float halfPLayerWidth;
    float halfPlayerHieght;
    public event System.Action OnDeath;
    [SerializeField] private float playerSpriteOffset;
    [SerializeField] private GameObject laserBeam;
    [SerializeField] private LayerMask obstcleLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        halfScreenHieght = Camera.main.orthographicSize;
        halfScreenWidth = Camera.main.aspect * halfScreenHieght;
        halfPLayerWidth = transform.localScale.x / 2f;
        halfPlayerHieght = transform.localScale.y / 2f;
        transform.position = new Vector3(0, halfPlayerHieght - halfScreenHieght+playerSpriteOffset, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        MoveThePlayer(input);
        //this line does not work cause transform.position is vectro3 but moveAmount is vector2, thois can be fixed by casting moveAmount to a vector3 like this - transform.position+=(vector3)moveAmount
        //transform.position += moveAmount;

        Teleport();

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position,transform.up,halfScreenHieght*2f,obstcleLayerMask);
        if(hitInfo.collider!=null)
        {
            ShootLaser();
        }
     }

    private void MoveThePlayer(Vector2 input)
    {
        Vector2 direction = input.normalized;
        Vector2 velocity = direction * speed;
        Vector2 moveAmount = velocity * Time.deltaTime;
        transform.Translate(moveAmount);
    }

    private void Teleport()
    {
        Vector2 temp = transform.position;
        if (transform.position.x > halfScreenWidth+halfPLayerWidth)
        {
            temp.x = -halfScreenWidth-halfPLayerWidth;
            transform.position = temp;
        }
        else if (transform.position.x < -halfScreenWidth-halfPLayerWidth)
        {
            temp.x = halfScreenWidth+halfPLayerWidth;
            transform.position = temp;
        }
        else if (transform.position.y > halfScreenHieght+halfPlayerHieght)
        {
            temp.y = -halfScreenHieght-halfPlayerHieght;
            transform.position = temp;
        }
        else if (transform.position.y <= -halfScreenHieght+halfPlayerHieght)
        {
            temp.y = -halfScreenHieght+halfPlayerHieght;
            transform.position = temp;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="obstacle")
        {
            Destroy(gameObject);
            Debug.Log("game over");
            if(OnDeath!=null)
            {
                OnDeath();
            }
        }
    }


    private void ShootLaser()
    {
        Vector3 laserSpawnposition = transform.position;
        laserSpawnposition.y = laserSpawnposition.y + halfPlayerHieght;
        GameObject newLaser = Instantiate(laserBeam, laserSpawnposition, Quaternion.Euler(0, 0, 0));
    }
}

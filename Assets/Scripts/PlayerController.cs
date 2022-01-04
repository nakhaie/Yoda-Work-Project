using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject    bullet;
    public float         speed = 1;
    public float         bulletSpeed;

    private Vector2 _horizontalArea;
    private Vector2 _verticalArea;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        locomotion(Vector3.right * (Input.GetAxis("Horizontal") * Time.deltaTime * speed));

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    private void Fire()
    {
        GameObject tempBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        
        tempBullet.GetComponent<Rigidbody>().AddForce(Vector3.up * bulletSpeed);
    }

    private void locomotion(Vector3 direction)
    {
        if (direction.x != 0)
        {
            if (direction.x > 0)
            {
                if (transform.position.x > _horizontalArea.y)
                {
                    direction.x = 0;
                }
            }
            else
            {
                if (transform.position.x < _horizontalArea.x)
                {
                    direction.x = 0;
                }
            }
        }

        transform.Translate(direction);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Hazard":
                other.GetComponent<Hazard>().TakeDestroy();
                break;
        }
    }

    public void SetLocomotionAreaLimit(float minHorizontal = 0,float maxHorizontal = 0, float minVertical = 0,float maxVertical = 0)
    {
        var localScale = transform.localScale;
        
        minHorizontal += localScale.x / 2;
        maxHorizontal -= localScale.x / 2;
        
        _horizontalArea  = new Vector2(minHorizontal, maxHorizontal);
        _verticalArea    = new Vector2(minVertical, maxVertical);
    }
}

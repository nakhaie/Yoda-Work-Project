using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator      animatorPlayer;
    public GameObject    bullet;
    public float         speed = 1;
    public float         bulletSpeed;
    public float         bulletRang = 4;

    private Vector2 _horizontalArea;
    private Vector2 _verticalArea;

    private List<GameObject> _bulletStash;

    private void Awake()
    {
        _bulletStash = new List<GameObject>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject unit = Instantiate(bullet, transform.position, Quaternion.identity);
            
            _bulletStash.Add(unit);
            unit.SetActive(false);
        }
    }


    // Update is called once per frame
    void Update()
    {
        locomotion(Vector3.right * (Input.GetAxis("Horizontal") * Time.deltaTime * speed));

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
            animatorPlayer.SetTrigger("Shoot");
        }

        CheckBullets();
    }

    private void Fire()
    {
        GameObject tempBullet = TakeBullet(); //Instantiate(bullet, transform.position, Quaternion.identity);
        
        tempBullet.GetComponent<Rigidbody>().velocity = Vector3.zero;
        tempBullet.SetActive(true);
        tempBullet.transform.position = transform.position;
        tempBullet.GetComponent<Rigidbody>().AddForce(Vector3.up * bulletSpeed);
    }
    
    private GameObject TakeBullet()
    {
        GameObject tempBullet = null;
        
        foreach (var unit in _bulletStash)
        {
            if (!unit.activeSelf)
            {
                tempBullet = unit;
                break;
            }
        }

        if (tempBullet == null)
        {
            GameObject unit = Instantiate(bullet, transform.position, Quaternion.identity);
            
            _bulletStash.Add(unit);
            unit.SetActive(false);

            tempBullet = unit;
        }

        return tempBullet;
    }
    
    private void CheckBullets()
    {
        foreach (var unit in _bulletStash)
        {
            if (unit.activeSelf)
            {
                if (Mathf.Abs(unit.transform.position.y - transform.position.y)  > bulletRang)
                {
                    unit.SetActive(false);
                }
            }
        }
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

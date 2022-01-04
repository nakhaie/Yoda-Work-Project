using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public float speed = 1;

    private float _deadArea;
    
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);

        if (transform.position.y < _deadArea)
        {
            TakeDestroy();
        }
    }

    public void SetDeadArea(float height)
    {
        _deadArea = height;
    }

    public void TakeDestroy()
    {
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Bullet":
                TakeDestroy();
                Destroy(other.gameObject);
                break;
        }
    }

    /*private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Bullet":
                TakeDestroy();
                Destroy(other.gameObject);
                break;
        }
    }*/
}

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
            Destroy(gameObject);
        }
    }

    public void SetDeadArea(float height)
    {
        _deadArea = height;
    }
    
}

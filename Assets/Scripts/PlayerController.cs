using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 1;
    public float playerMoveArea = 1;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            transform.Translate(Vector3.right * (Input.GetAxis("Horizontal") * Time.deltaTime * speed));
        }
    }
}

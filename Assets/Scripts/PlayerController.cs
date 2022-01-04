using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;

    private Vector2 _horizontalArea;
    private Vector2 _verticalArea;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 locomotion = Vector3.right * (Input.GetAxis("Horizontal") * Time.deltaTime * speed);

        if (locomotion.x != 0)
        {
            if (locomotion.x > 0)
            {
                if (transform.position.x > _horizontalArea.y)
                {
                    locomotion.x = 0;
                }
            }
            else
            {
                if (transform.position.x < _horizontalArea.x)
                {
                    locomotion.x = 0;
                }
            }
        }

        transform.Translate(locomotion);
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

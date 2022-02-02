using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform          background;
    
    private float             _viewportHeight;
    private Camera            _mainCamera;
    private PlayerController  _player;
    private HazardController  _hazardController;
    private UIController _uIController;

    private void Awake()
    {
        //_mainCamera     = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        
        _mainCamera       = FindObjectOfType<Camera>();
        _player           = FindObjectOfType<PlayerController>();
        _hazardController = FindObjectOfType<HazardController>();
        _uIController     = FindObjectOfType<UIController>();

        _viewportHeight = _mainCamera.orthographicSize;
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        Vector3 cameraPosition = _mainCamera.transform.position;
        
        _player.SetLocomotionAreaLimit(_viewportHeight * -1, _viewportHeight);

        SetBackground(cameraPosition, _mainCamera.farClipPlane, Vector2.one * _viewportHeight * 2);
        
        _hazardController.Init(_viewportHeight, cameraPosition, _player.transform.position);
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            if(Time.timeScale > 0)
            {
                Time.timeScale = 0;
                _uIController.SetPause(true);
            }
            else
            {
                Time.timeScale = 1;
                _uIController.SetPause(false);
            }
        }
    }

    private void SetBackground(Vector3 cameraPosition, float cameraFarDistance, Vector2 viewportSize)
    {
        cameraPosition.z     += cameraFarDistance;
        background.position  = cameraPosition;
        
        background.localScale = new Vector3(viewportSize.x, viewportSize.y, 1);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        if (Application.isPlaying)
        {
            Gizmos.DrawWireCube(_mainCamera.transform.position, Vector3.one * _viewportHeight * 2);
        }

    }

    private void OnDrawGizmosSelected()
    {
        
    }
#endif
}

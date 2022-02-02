using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HazardController : MonoBehaviour
{
    public GameObject hazardPrefab;
    public float      cooldown;
    
    private float _minSpawnArea;
    private float _maxSpawnArea;
    private float _curCooldown;

    private float _hazardDestroyArea;

    private float _score;

    // Start is called before the first frame update
    private void Start()
    {
        _curCooldown = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_curCooldown < cooldown)
        {
            _curCooldown += Time.deltaTime;
        }
        else
        {
            Vector3 randomPos = transform.position;

            randomPos.x = Random.Range(_minSpawnArea, _maxSpawnArea);
            
            GameObject hazard = Instantiate(hazardPrefab, randomPos, Quaternion.identity);
            
            hazard.GetComponent<Hazard>().SetDeadArea(_hazardDestroyArea);
            
            _curCooldown = 0;
        }

        _score = Time.time;
    }

    public void Init(float cameraSize, Vector3 cameraPosition,Vector3 playerPosition)
    {
        Vector3 pos = cameraPosition;

        var hazardLocalScale = hazardPrefab.transform.localScale;
        
        pos.y += cameraSize + (hazardLocalScale.y / 2);
        pos.z = playerPosition.z;

        _hazardDestroyArea = cameraPosition.y - (cameraSize + (hazardLocalScale.y / 2));
        
        _minSpawnArea = (pos.x - cameraSize) + (hazardLocalScale.x / 2);
        _maxSpawnArea = (pos.x + cameraSize) - (hazardLocalScale.x / 2);

        transform.position = pos;
    }
    
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        
        if (Application.isPlaying)
        {
            Vector3 from   = transform.position;
            Vector3 to     = transform.position;

            from.x   = _minSpawnArea;
            to.x     = _maxSpawnArea;
            
            Gizmos.DrawLine(from, to);
        }

    }

#endif
}

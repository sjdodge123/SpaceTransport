using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    private Camera m_Camera;
    
    // Use this for initialization
    void Awake()
    {
        m_Camera = GetComponentInChildren<Camera>();
       
    }

    void Start()
    {

        //GameVars.maxBounds = m_Camera.orthographicSize;
       
    }

    public void ExpandCamera(Vector2 newBounds)
    {

        
    }
}

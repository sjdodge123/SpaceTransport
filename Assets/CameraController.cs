using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public float scrollSpeed = 1f;
    private Camera m_Camera;
    private Vector3 moveDir;
    private bool drag = false;
    private Vector3 mouseOrigin;

    // Use this for initialization
    void Awake()
    {
        m_Camera = GetComponentInChildren<Camera>();

    }

    void Start()
    {

        //GameVars.maxBounds = m_Camera.orthographicSize;
    }

    public void LateUpdate()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Camera.main.orthographicSize -= scrollSpeed;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Camera.main.orthographicSize += scrollSpeed;
        }
        if (Input.GetMouseButton(2))
        {
            moveDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            if (drag == false)
            {
                drag = true;
                mouseOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            }
        }
        else
        {
            drag = false;
        }
        if (drag)
        {
           transform.position = mouseOrigin - moveDir;
        }
    }

    public void ExpandCamera(Vector2 newBounds)
    {


    }

}

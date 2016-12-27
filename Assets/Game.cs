using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour
{
    public CameraController camera;
    public List<int> levels;
    public GameObject spawnBase;
    private BoxCollider2D gameBounds;
    private float boundPadding = 1;
    private int currentLevel = 0;

    public void Awake()
    {
        gameBounds = GetComponentInChildren<BoxCollider2D>();
        int layerID = LayerMask.NameToLayer("Resource");
        foreach (GameObject node in FindObjectsOfType<GameObject>())
        {
            if (node.layer == layerID)
            {
                GameVars.resourceNodes.Add(node);

                if (!gameBounds.bounds.Contains(node.transform.position))
                {
                    GameVars.outerResourceNodes.Add(node);
                }
            }
        }
        GameVars.maxBounds = new Rect(gameBounds.offset - gameBounds.size / 2, gameBounds.size);
    }

    // Use this for initialization
    void Start()
    {
        //ExpandMap();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void LateUpdate()
    {
        if(GameVars.playerMoney > levels[currentLevel])
        {
            currentLevel++;
            ExpandMap();
            ProduceShip[] produceShip = spawnBase.GetComponents<ProduceShip>();
            foreach(ProduceShip script in produceShip)
            {
                if(script.enabled == false)
                {
                    script.enabled = true;
                }
            }  
        }
    }

    void ExpandMap()
    {
        float wi = gameBounds.size.x / 2;
        float hi = gameBounds.size.y / 2;
        Vector2 nodePos = FindClosestNode();
        float wn = Mathf.Abs(nodePos.x) + boundPadding;
        float hn = Mathf.Abs(nodePos.y) + boundPadding;
        //camera.ExpandCamera(newBounds);

        var width = Mathf.Max(wi + wn, gameBounds.size.x);
        var height = Mathf.Max(hi + hn, gameBounds.size.y);
        gameBounds.offset = new Vector2(Mathf.Sign(nodePos.x) * (width - gameBounds.size.x) / 2, Mathf.Sign(nodePos.y) * (height - gameBounds.size.y) / 2);
        gameBounds.size = new Vector2(width, height);
        GameVars.maxBounds = new Rect(gameBounds.offset - gameBounds.size / 2, gameBounds.size);
    }

    public void OnDrawGizmos()
    {
        if(gameBounds != null)
        {
            Gizmos.color = new Color(1, 0, 0, 0.2F);
            Gizmos.DrawCube(gameBounds.offset, gameBounds.size);
        }
    }

    private Vector2 FindClosestNode()
    {
        float minDistance = Mathf.Infinity;
        Vector2 closestPos = Vector2.zero;
        foreach (GameObject node in GameVars.outerResourceNodes)
        {
            var currentDistance = node.transform.position.magnitude;
            if (minDistance > currentDistance)
            {
                minDistance = currentDistance;
                closestPos = node.transform.position;
            }
        }
        return closestPos;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}

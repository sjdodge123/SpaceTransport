using UnityEngine;
using System.Collections;
using System;

public class InputListener : MonoBehaviour {

    public GameObject spawnObject;
    private CircleCollider2D spawnCollider;
    private bool wellVisible = false;
    // Use this for initialization
    void Start () {
        spawnCollider = spawnObject.GetComponent<CircleCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            LeftMouseHeld();
        }
        if (Input.GetMouseButtonUp(0))
        {
            LeftMousePressed();
        }
        if (Input.GetMouseButtonUp(1))
        {
            RightMousePressed();
        }
        if (Input.GetKeyDown("space")){
            foreach(GameObject wellRadii in GameVars.wellRadii)
            {
                if (wellVisible)
                {
                    wellRadii.SetActive(true);
                }
                else
                {
                    wellRadii.SetActive(false);
                }
                wellVisible = !wellVisible;
            }
        }
    }

    private void LeftMouseHeld()
    {
        ShowRadii();
    }

    private void LeftMousePressed()
    {
        SpawnGravityWell();
    }


    private void RightMousePressed()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D collision = Physics2D.OverlapPoint(mousePos);
        if(collision == null)
        {
            return;
        }
        if (collision.gameObject.CompareTag(spawnObject.tag))
        {
            Destroy(collision.gameObject);
        }
    }


    private void ShowRadii()
    {

    }

    private void SpawnGravityWell()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 1;
        if (CollidesWithSpawnObject(mousePos, spawnCollider.radius))
        {
            return;
        }
        var gravWell = Instantiate(spawnObject, mousePos, Quaternion.identity) as GameObject;
    }

    private bool CollidesWithSpawnObject(Vector3 pos, float radius)
    {
        Collider2D[] collisions = Physics2D.OverlapCircleAll(pos, radius);
        if (collisions.Length > 0)
        {
            return true;
        }
        return false;
    }
}

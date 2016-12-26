using UnityEngine;
using System.Collections;

public class ProduceShip : MonoBehaviour {

    public GameObject spawnShip;
    public Vector3 spawnVelocity;
    public Vector3 spawnOffset;
    public float interval;


    private Vector3 spawnPos;
    private float startTime;
    // Use this for initialization
    void Start () {
        startTime = Time.time;
        
       

        spawnPos = gameObject.transform.position;
        spawnPos += spawnOffset;
        //spawnPos.z = 1; //In case forgotten.
        spawnVelocity.z = 0; //In case forgotten.
    }
	
	// Update is called once per frame
	void Update () {

        if (Time.time - startTime > interval)
        {
            startTime = Time.time;
            SpawnObject();
        }

    }

    private void SpawnObject()
    {
        var spawned = Instantiate(spawnShip, spawnPos, Quaternion.identity) as GameObject;
        spawned.GetComponent<Rigidbody2D>().velocity = spawnVelocity;
    }
}

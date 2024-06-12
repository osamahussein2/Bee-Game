using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class placementHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject jellyMaker;
    public Vector3 worldPosition;
    public GameObject player;
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPosition = transform.position;
        worldPosition.x += .5f;
        worldPosition.y -= 1f;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Instantiate the prefab at the spawner's position and rotation
            Instantiate(jellyMaker, worldPosition, Quaternion.identity);
        }
    }
}

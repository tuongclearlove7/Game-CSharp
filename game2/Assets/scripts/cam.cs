using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    private Transform character;
    void Start()
    {
        character = GameObject.Find("wukong").transform;
    }
    // Update is called once per frame
    void Update()
    {
        if (character != null)
        {
            Vector3 temp = transform.position;
            temp.x = character.position.x;
            transform.position = temp;
        }
    }
}

















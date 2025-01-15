using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Camerafollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void Update()
    {
        transform.position = new Vector3(
            player.position.x+offset.x,
            player.position.y+offset.y,
            offset.z
        );
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform Player;

    private void FixedUpdate()
    {
        transform.position = new Vector3(Player.position.x, transform.position.y, transform.position.z);
    }
}

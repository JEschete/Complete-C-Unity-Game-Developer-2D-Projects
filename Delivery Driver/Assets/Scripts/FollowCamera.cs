using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // This thing's (camera) should be the same as the player's position.
    [SerializeField] GameObject thingToFollow;

    void LateUpdate()
    {
       transform.position = thingToFollow.transform.position + new Vector3 (0, 0, -10);
    }
}

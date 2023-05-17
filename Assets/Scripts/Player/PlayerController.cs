using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;

    public float speed = 1f;

    void Update()
    {
        var pos = target.position;
        pos.y = transform.position.y;
        pos.x = transform.position.x;

        transform.position = Vector3.Lerp(transform.position, pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }
}

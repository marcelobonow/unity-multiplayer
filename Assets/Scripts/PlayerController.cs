using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        if (!Application.isFocused) return;

        float2 input = float2.zero;
        if (Input.GetKey(KeyCode.W))
            input.y += 1;
        if (Input.GetKey(KeyCode.S))
            input.y -= 1;
        if (Input.GetKey(KeyCode.D))
            input.x += 1;
        if (Input.GetKey(KeyCode.A))
            input.x -= 1;

        if (math.length(input) > 0)
        {
            var movement = math.normalize(input) * Time.deltaTime * speed;
            transform.localPosition += new Vector3(movement.x, 0, movement.y);
        }
    }
}

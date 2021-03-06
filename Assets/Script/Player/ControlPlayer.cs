/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
    public Transform player;
    [SerializeField]
    private float speed = 50f;
    

    void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.x = mousePos.x > 3.0f ? 3.0f : mousePos.x;
        mousePos.x = mousePos.x < -3.0f ? -3.0f : mousePos.x;
        mousePos.y = mousePos.y > 4.0f ? 4.0f : mousePos.y;
        mousePos.y = mousePos.y < -4.0f ? -4.0f : mousePos.y;
        player.position = Vector2.MoveTowards(player.position,
        new Vector2(mousePos.x, mousePos.y),speed * Time.deltaTime);

    }

     
}*/
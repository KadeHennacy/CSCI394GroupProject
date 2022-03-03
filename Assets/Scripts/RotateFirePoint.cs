using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFirePoint : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 mousePosition;
    public Camera sceneCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mousePosition = sceneCam.ScreenToWorldPoint(Input.mousePosition);
        
        Vector2 aimDirection = mousePosition - rb.position;

        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }
}

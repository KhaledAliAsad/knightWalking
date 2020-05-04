using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterGrounding : MonoBehaviour
{
    [SerializeField]
    private Transform leftFoot;
    [SerializeField]
    private Transform rightFoot;
    [SerializeField]
    private float maxDistance;
    [SerializeField]
    private LayerMask layerMask;

    public bool isGrounded { get; private set; }

    // Update is called once per frame
    void Update()
    {
        CheckFootForGrounding(leftFoot);
        if(isGrounded ==  false)
             CheckFootForGrounding(rightFoot);
    }

    private void CheckFootForGrounding(Transform foot)
    {
        var raycastHit = Physics2D.Raycast(foot.position, Vector2.down, maxDistance, layerMask);
        Debug.DrawRay(foot.position, Vector3.down * maxDistance, Color.red);
        if(raycastHit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}

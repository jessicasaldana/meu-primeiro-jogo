using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallingTime;
    public BoxCollider2D boxCollider;
    public TargetJoint2D Joint;

    void Falling() //plataforma cai e atravessa o chão
    {
        boxCollider.enabled = false;
        Joint.enabled = false;
        Destroy(gameObject, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Invoke("Falling", fallingTime); // tempo antes da queda da plataforma
        }
    }
}

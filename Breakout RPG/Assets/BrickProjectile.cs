using UnityEngine;

public class BrickProjectile : MonoBehaviour
{
    public float pSpeed = 3f;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 dir = Vector2.down;
        rb.velocity = dir * pSpeed;

        /*
        if (v.sqrMagnitude > sqrMaxVel)
        {
            rb.velocity = v.normalized * maxVelocity;
        }
        */
    }

    public void DestroyProjectile()
    {
        Destroy(this.gameObject);
    }
}

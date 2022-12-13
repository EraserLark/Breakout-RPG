using UnityEngine;

public class testPaddle : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 10f;
    public Vector2 moveDir = new Vector2();

    float maxBounceAngle = 75f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float direction = Input.GetAxisRaw("Horizontal");

        if(direction == 0)
        {
            moveDir = Vector2.zero;
        }
        else if(direction == 1)
        {
            moveDir = Vector2.right;
        }
        else if (direction == -1)
        {
            moveDir = Vector2.left;
        }
    }

    private void FixedUpdate()
    {
        if(moveDir != Vector2.zero)
        {
            Vector2 moveVelocity = moveDir * moveSpeed;
            rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
        }
    }

    //Bounces ball off paddle from an angle - https://youtu.be/RYG8UExRkhA?t=2728
    private void OnCollisionEnter2D(Collision2D collision)
    {
        testBall ball = collision.gameObject.GetComponent<testBall>();

        if (ball != null)   //Checks if what collided with paddle is ball
        {
            Vector2 paddlePosition = this.transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            //Horizontal
            float offset = paddlePosition.x - contactPoint.x;
            float width = collision.otherCollider.bounds.size.x / 2;

            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.GetComponent<Rigidbody2D>().velocity);   //Returns angle as pos or neg
            float bounceAngle = (offset / width) * maxBounceAngle;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -maxBounceAngle, maxBounceAngle);

            //Check if ball hits top half or bottom half of paddle
            Vector2 normal = collision.GetContact(0).normal;
            Vector2 bounceVDir = Vector2.up;

            //Hit bottom
            if (normal.y > 0)
            {
                bounceVDir = Vector2.down;
                newAngle = -newAngle;
            }

            //Final calcs
            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.GetComponent<Rigidbody2D>().velocity = rotation * bounceVDir * ball.GetComponent<Rigidbody2D>().velocity.magnitude;    //Magnitude is speed of ball, essentially
        }
    }
}

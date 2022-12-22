using UnityEngine;

public class DeathField : MonoBehaviour
{  
    public delegate void BallCollide();     //Delegate
    public event BallCollide ballIsDead;   //Event

    PlayerManager playerManager;
    private void Start()
    {
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        testBall ball = collision.gameObject.GetComponent<testBall>();
        BrickProjectile bp = collision.gameObject.GetComponent<BrickProjectile>();
        if (ball != null)
        {
            ballIsDead?.Invoke();   //If 'ballIsDead' is not null...
            playerManager.TakeDamage(3);
        }
        else if(bp != null)
        {
            playerManager.TakeDamage(1);
            bp.DestroyProjectile();
        }
    }
}

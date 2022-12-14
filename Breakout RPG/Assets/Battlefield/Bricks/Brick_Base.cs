using UnityEngine;

public class Brick_Base : MonoBehaviour
{
    public int HP = 1;
    Color[] healthColors = { Color.red, Color.blue, Color.yellow };
    Color brickColor;

    private void Awake()
    {
        ChangeColor(HP);
    }

    private void OnValidate()
    {
        ChangeColor(HP);
    }

    void ChangeColor(int hp)
    {
        int arrayHP = hp - 1;
        brickColor = healthColors[arrayHP];
        GetComponent<SpriteRenderer>().color = brickColor;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        testBall ball = collision.gameObject.GetComponent<testBall>();
        if (ball != null)
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        this.HP--;

        if(HP <= 0)
        {
            BrickDestroy();
        }
        else
        {
            ChangeColor(HP);
        }
    }

    void BrickDestroy()
    {
        GetComponentInParent<BrickManager>().BrickBroken();
        Destroy(this.gameObject);
        print("Kaboom");
    }
}

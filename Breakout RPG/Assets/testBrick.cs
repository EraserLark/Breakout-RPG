using UnityEngine;

public class testBrick : MonoBehaviour
{
    public int HP = 1;
    Color[] healthColors = { Color.red, Color.blue, Color.yellow };
    Color brickColor;

    private void Awake()
    {
        ChangeColor(HP);
    }

    void ChangeColor(int hp)
    {
        /*
        switch(hp)
        {
            case 1:
                brickColor = Color.red;
                break;
            case 2:
                brickColor = Color.blue;
                break;
            case 3:
                brickColor = Color.yellow;
                break;
            default:
                brickColor = Color.black;
                break;
        }
        */

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

    void TakeDamage()
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

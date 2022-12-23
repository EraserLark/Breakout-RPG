using UnityEngine;
using UnityEditor;

public class Brick_Base : MonoBehaviour
{
    public int HP = 1;
    public bool attacking = false;
    Color[] healthColors = { Color.red, Color.blue, Color.yellow };
    Color brickColor;

    Object prefProjectile;

    private void Awake()
    {
        prefProjectile = AssetDatabase.LoadAssetAtPath("Assets/Battlefield/Bricks/BrickProjectile.prefab", typeof(GameObject));
        ChangeColor(HP);
        StartRandTimer();
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

    void BrickAttack()
    {
        if(attacking)
        {
            Instantiate(prefProjectile, this.transform);
        }
        StartRandTimer();
    }

    void StartRandTimer()
    {
        float waitTime = Random.Range(1f, 10f);
        Invoke("BrickAttack", waitTime);
    }

    public void AttackState(bool state)
    {
        attacking = state;
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

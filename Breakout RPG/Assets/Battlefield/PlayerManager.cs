using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    TurnManager turnMan;
    UIManager uiMan;

    private void Awake()
    {
        turnMan = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        uiMan = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    private void Start()
    {
        int health = PlayerData.CurrentHealth;
        uiMan.SetHealth(health);
    }

    public void TakeDamage(int dmg)
    {
        int newHealth = PlayerData.ChangeHealth(-dmg);
        uiMan.SetHealth(newHealth);

        if (newHealth <= 0)
        {
            turnMan.SwapTurnState("Defeat");
        }
    }
}

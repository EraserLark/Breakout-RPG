using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    TurnManager turnMan;
    UIManager uiMan;

    private void Start()
    {
        turnMan = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        uiMan = GameObject.Find("Canvas").GetComponent<UIManager>();

        int health = PlayerData.CurrentHealth;
        SetUIHealth(health);
    }

    public void TakeDamage(int dmg)
    {
        int newHealth = PlayerData.ChangeHealth(-dmg);
        SetUIHealth(newHealth);

        if (newHealth <= 0)
        {
            turnMan.SwapTurnState("Defeat");
        }
    }

    void SetUIHealth(int newHealth)
    {
        uiMan.SetHealth(newHealth);
    }
}

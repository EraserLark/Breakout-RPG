using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    TurnManager turnMan;

    private void Awake()
    {
        turnMan = GameObject.Find("TurnManager").GetComponent<TurnManager>();
    }

    public void TakeDamage(int dmg)
    {
        int newHealth = PlayerData.ChangeHealth(-dmg);
        print("Health = " + newHealth);

        if(newHealth <= 0)
        {
            turnMan.SwapTurnState("Defeat");
        }
    }
}

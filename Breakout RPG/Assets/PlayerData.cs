using UnityEngine;

public static class PlayerData
{
    private static int maxHealth = 15;
    private static int currentHealth = 15;
    static int playerMoney = 30;

    public static int MaxHealth { get { return maxHealth; } }
    public static int CurrentHealth { get { return currentHealth; } }

    public static int ChangeHealth(int amt)
    {
        currentHealth += amt;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        return currentHealth;
    }
}

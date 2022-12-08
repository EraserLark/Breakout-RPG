using UnityEngine;

public static class PlayerData
{
    public static int maxHealth = 15;
    static int currentHealth = 15;
    static int playerMoney = 30;

    public static int ChangeHealth(int amt)
    {
        currentHealth += amt;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        return currentHealth;
    }
}

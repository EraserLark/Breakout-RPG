public static class PlayerData
{
    static int playerHealth = 10;
    static int playerMoney = 30;

    public static int ChangeHealth(int amt)
    {
        playerHealth += amt;
        return playerHealth;
    }
}

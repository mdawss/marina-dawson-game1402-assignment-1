using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int PlayerHealthAmount = 0;
    public int PlayerMaxHealthAmount = 0;

    public int PlayerCoinsAmount = 0;
    public int PlayerCoinMax = 0;

    public int PlayerHeartAmount = 0;
    public int PlayerHeartMax = 0;

    public void IncrementCount(Collectibles collectible, int amount)
    {
        switch (collectible)
        {
            case HeartTest test :
                PlayerHeartAmount += amount;
                break;
            case CoinTest test2 :
                PlayerCoinsAmount += amount;
                break;
        }
    }

    public void DecrementCount(Collectibles collectible, int amount)
    {
        
    }

// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

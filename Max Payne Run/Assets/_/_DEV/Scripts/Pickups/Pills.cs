using UnityEngine;

public class Pills : Pickup
{
    [SerializeField] int scoreAmount = 100;
    
    ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    protected override void OnPickup()
    {
        scoreManager.IncreaseScore(scoreAmount);
    }
}

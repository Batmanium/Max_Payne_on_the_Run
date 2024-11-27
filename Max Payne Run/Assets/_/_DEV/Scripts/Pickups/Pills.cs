using UnityEngine;

public class Pills : Pickup
{
    [SerializeField] int scoreAmount = 100;
    [SerializeField] AudioSource pillFX;

    const string playerString = "Player";

    ScoreManager scoreManager;

    public void Init(ScoreManager scoreManager)
    {
        this.scoreManager = scoreManager;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerString))
        {
            OnPickup();
            Destroy(gameObject);
            GetComponent<AudioSource>().Play();
        }
    }

    protected override void OnPickup()
    {
        scoreManager.IncreaseScore(scoreAmount);
    }
}

using UnityEngine;

public class Bottle : Pickup
{
    [SerializeField] float adjustChangeMoveSpeedAmount = 3;

    const string playerString = "Player";

    LevelGenerator levelGenerator;

    public void Init(LevelGenerator levelGenerator)
    {
        this.levelGenerator = levelGenerator;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerString))
        {
            OnPickup();
            Destroy(gameObject);

        }
    }

    protected override void OnPickup()
    {
        levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmount);
    }
}

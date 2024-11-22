using UnityEngine;

public class Bottle : Pickup
{
    [SerializeField] float adjustChangeMoveSpeedAmount = 3;

    LevelGenerator levelGenerator;

    private void Start()
    {
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }

    protected override void OnPickup()
    {
        levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmount);
    }
}

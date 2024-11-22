using UnityEngine;

public class Pills : Pickup
{
    protected override void OnPickup()
    {
        Debug.Log("Add 100 points");
    }
}

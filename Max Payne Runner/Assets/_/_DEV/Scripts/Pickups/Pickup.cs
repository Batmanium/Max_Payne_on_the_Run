using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;
    [SerializeField] AudioClip _clip;

    const string playerString = "Player";


    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    protected abstract void OnPickup();

    protected void PlaySound()
    {
        AudioManager.instance.PlaySoundAt(transform.position, _clip);
    }
}

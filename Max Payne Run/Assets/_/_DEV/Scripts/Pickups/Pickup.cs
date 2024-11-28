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

    private void OnDestroy() => PlaySound();

    protected abstract void OnPickup();

    private void PlaySound()
    {
        AudioManager.instance.PlaySoundAt(transform.position, _clip);
    }
}

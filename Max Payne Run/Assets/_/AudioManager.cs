using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Instance Off");
            Destroy(gameObject);
            return;
        }

        instance = this;
    }
    public void PlaySoundAt(Vector3 pos, AudioClip clip)
    {
        GameObject gO = new GameObject();
        var source = gO.AddComponent<AudioSource>();
        source.playOnAwake = false;
        
        gO.transform.position = pos;

        source.clip = clip;
        source.Play();

        Destroy(gO, clip.length + .5f);
    }

}

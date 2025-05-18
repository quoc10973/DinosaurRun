using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioSource effectSouce;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip dropSound;
    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private AudioClip crackEggSound;
    [SerializeField] private bool hasPlayedEffectSound = false;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }
    }

    public bool HasPlayedEffectSound()
    {
        return hasPlayedEffectSound;
    }

    public void SetHasPlayedEffectSound(bool value)
    {
        hasPlayedEffectSound = value;
    }
    void Start()
    {
        effectSouce.Stop();
        hasPlayedEffectSound = true;

    }

    public void PlayJumpSound()
    {
        effectSouce.PlayOneShot(jumpSound);
    }

    public void PlayDropSound()
    {
        effectSouce.PlayOneShot(dropSound);
    }

    public void PlayHurtSound()
    {
        effectSouce.PlayOneShot(hurtSound);
    }

    public void PlayCrackEggSound()
    {
        effectSouce.PlayOneShot(crackEggSound);
    }


}

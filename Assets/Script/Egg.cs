using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField ]private GameObject player;

    void HideEggShowPlayer()
    {   
        AudioManager.instance.PlayCrackEggSound();
        gameObject.SetActive(false);
        player.SetActive(true);
    }

}

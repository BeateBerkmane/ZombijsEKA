using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int value = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            GameManager gm = FindAnyObjectByType<GameManager>();
            gm.AddScore(value);
            Destroy(gameObject);
        }
        AudioManager.Instance.PlaySFX(AudioManager.Instance.collectSound);
    }
}
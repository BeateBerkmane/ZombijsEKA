using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int value = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            
            AudioManager.Instance.PlaySFX(AudioManager.Instance.collectSound);

            
            GameManager.Instance.AddScore(value);

            
            gameObject.SetActive(false);
        }
    }
}
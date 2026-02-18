using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            GameManager gm = FindAnyObjectByType<GameManager>();
            gm.zombiesInDeathZone++;

            // Ja visi zombiji ir iekšā → lose
            if (gm.zombiesInDeathZone >= gm.zombies.Length)
            {
                gm.LoseGame();
            }
        }
    }
}
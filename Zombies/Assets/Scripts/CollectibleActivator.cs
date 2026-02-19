using UnityEngine;
using System.Collections;

public class CollectibleActivator : MonoBehaviour
{
    public GameObject[] collectibles;
    public float minDelay = 0.1f;
    public float maxDelay = 0.3f;

    void Start()
    {
        
        foreach (var c in collectibles)
            c.SetActive(false);

        StartCoroutine(ActivateCollectibles());
    }

    IEnumerator ActivateCollectibles()
    {
        for (int i = 0; i < collectibles.Length; i++)
        {
            
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            collectibles[i].SetActive(true);
        }
    }
}
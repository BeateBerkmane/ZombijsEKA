using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject selectedZombie;
    public GameObject [] zombies;
    public Vector3 selectedSize;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        selectZombie(2);
        //Debug.Log("selected" + selectedZombie.name);
    }

    void selectZombie(int index)
    {
        selectedZombie = zombies[index];
        selectedZombie.transform.localScale = selectedSize;
        Debug.Log("selected" + selectedZombie.name);
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}

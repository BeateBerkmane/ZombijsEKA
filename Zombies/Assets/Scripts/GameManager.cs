using UnityEngine;
using UnityEngine.InputSystem;
public class GameManager : MonoBehaviour
{
    public GameObject selectedZombie;
    public GameObject [] zombies;
    public Vector3 selectedSize;
    private InputAction left, right;
    private int selectedIndex;
    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        selectZombie(0);
        left = InputSystem.actions.FindAction("PrewZombie");
        right = InputSystem.actions.FindAction("NextZombie");
        //Debug.Log("selected" + selectedZombie.name);
    }

    void selectZombie(int index)
    {
        if (selectedZombie != null)
            selectedZombie.transform.localScale = Vector3.one;
        selectedZombie = zombies[index];
        selectedZombie.transform.localScale = selectedSize;
        Debug.Log("selected" + selectedZombie.name);
    }
    // Update is called once per frame
    void Update()
    {
        if (left.WasReleasedThisFrame())
        {
            selectedIndex--;
            selectZombie(selectedIndex);
            Debug.Log("Left is pressed");
            
        }
        if (right.WasPressedThisFrame())
        {
            selectedIndex++;
            selectZombie(selectedIndex);
            Debug.Log("Right is pressed");
            
        }
    }
}

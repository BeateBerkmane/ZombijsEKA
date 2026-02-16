using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class GameManager : MonoBehaviour
{
    public GameObject selectedZombie;
    public GameObject [] zombies;
    public Vector3 selectedSize;
    private InputAction left, right, Jump;
    private int selectedIndex;
    public Vector3 pushForce;
    public TMP_Text timerText;
    private float time = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        selectZombie(0);
        left = InputSystem.actions.FindAction("PrewZombie");
        right = InputSystem.actions.FindAction("NextZombie");
        Jump = InputSystem.actions.FindAction("Jump"); 
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
            if (selectedIndex < 0)
                selectedIndex = 3;
            selectZombie(selectedIndex);
            Debug.Log("Left is pressed");

        }

        if (right.WasPressedThisFrame())
        {
            selectedIndex++;
            if (selectedIndex >= zombies.Length)
                selectedIndex = 0;
            selectZombie(selectedIndex);
            Debug.Log("Right is pressed");

        }

        if (Jump.WasPressedThisFrame())
        {
            Rigidbody rb = selectedZombie.GetComponent<Rigidbody>();
            rb.AddForce(pushForce);
            Debug.Log("Jump is pressed");
        }
        time += Time.deltaTime;
        timerText.text = "Time:" + time.ToString("F1") + "s";
    }
}

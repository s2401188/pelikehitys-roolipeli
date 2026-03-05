using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    private DoorController currentDoor;

    [Header("UI")]
    private GameObject buttonParent;
    private Button openButton;
    private Button closeButton;
    private Button lockButton;
    private Button unlockButton;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // UI
        buttonParent = GameObject.Find("DoorButtons");

        openButton = GameObject.Find("OpenButton").GetComponent<Button>();
        closeButton = GameObject.Find("CloseButton").GetComponent<Button>();
        lockButton = GameObject.Find("LockButton").GetComponent<Button>();
        unlockButton = GameObject.Find("UnlockButton").GetComponent<Button>();

        openButton.onClick.AddListener(OnOpenButtonPress);
        closeButton.onClick.AddListener(OnCloseButtonPress);
        lockButton.onClick.AddListener(OnLockButtonPress);
        unlockButton.onClick.AddListener(OnUnlockButtonPress);

        buttonParent.SetActive(false);
    }

    void Update()
    {
        // X ja Y akselit 2D-peliss�
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        HandleKeyboardDoorInput();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement.normalized * moveSpeed;
    }

    // ======================
    // Oven k�ytt� E-n�pp�imell�
    // ======================
    void HandleKeyboardDoorInput()
    {
        if (currentDoor == null) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            currentDoor.ReceiveAction(DoorController.Toiminto.Avaa);
        }
    }

    // ======================
    // 2D Triggerit
    // ======================
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Door"))
        {
            currentDoor = other.GetComponent<DoorController>();
            buttonParent.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Door"))
        {
            currentDoor = null;
            buttonParent.SetActive(false);
        }
    }

    // ======================
    // UI-napit
    // ======================
    void OnOpenButtonPress()
    {
        currentDoor?.ReceiveAction(DoorController.Toiminto.Avaa);
    }

    void OnCloseButtonPress()
    {
        currentDoor?.ReceiveAction(DoorController.Toiminto.Sulje);
    }

    void OnLockButtonPress()
    {
        currentDoor?.ReceiveAction(DoorController.Toiminto.Lukitse);
    }

    void OnUnlockButtonPress()
    {
        currentDoor?.ReceiveAction(DoorController.Toiminto.AvaaLukitus);
    }
}
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Player movement speed
    public float Speed = 10f;

    // Text to show scores
    public TextMeshProUGUI ScoreText;

    // Text to show game result
    public TextMeshProUGUI ResultText;

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private float score;
    private bool isGameOver = false;

    private MyInputActions controls;
    private InputAction jumpAction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Awake()
    {
        controls = new MyInputActions();
        jumpAction = controls.Player.Jump;
        controls.Player.Jump.performed += context =>Jump_performed();
    }

    private void OnEnable()
    {
        jumpAction.Enable();
    }

    private void OnDisable()
    {
        jumpAction.Disable();
    }

    private void Jump_performed()
    {
        rb.AddForce(Vector3.up * Speed / 2, ForceMode.Impulse);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0f, movementY);
        rb.AddForce(movement * Speed);
    }

    /// <summary>
    /// Handle user input
    /// </summary>
    /// <param name="movementValue"></param>
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    /// <summary>
    /// Handle trigger enter event
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (!isGameOver)
        {
            if (other.CompareTag("Enemy"))
            {
                other.gameObject.SetActive(false);
                score -= 2;
                SetText();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!isGameOver)
        {
            if (collision.gameObject.CompareTag("PickUp"))
            {
                // deactive the pickup collied with player
                collision.gameObject.SetActive(false);
                score++;
                SetText();
            }
        }
    }

    /// <summary>
    /// Update UI text
    /// </summary>
    private void SetText()
    {
        ScoreText.text = "SCORE:" + score.ToString();

        if (score > 3)
        {
            ResultText.text = "You Win!";
            ResultText.gameObject.SetActive(true);
            isGameOver = true;
        }

        if (score < 0)
        {
            ResultText.text = "You Lose!";
            ResultText.gameObject.SetActive(true);
            isGameOver = true;
        }
    }
}
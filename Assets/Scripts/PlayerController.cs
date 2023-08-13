using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        if(other.CompareTag("PickUp"))
        {
            // deactive the pickup collied with player
            other.gameObject.SetActive(false);
            score++;
            SetText();
        }

        if(other.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            score -= 2;
            SetText();
        }
    }

    /// <summary>
    /// Update UI text
    /// </summary>
    private void SetText()
    {
        ScoreText.text = "SCORE:" + score.ToString();

        if(score > 3)
        {
            ResultText.text = "You Win!";
            ResultText.gameObject.SetActive(true);
        }

        if(score < 0)
        {
            ResultText.text = "You Lose!";
            ResultText.gameObject.SetActive(true);
        }
    }
}
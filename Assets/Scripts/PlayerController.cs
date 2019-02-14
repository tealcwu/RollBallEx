using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    int score = 0;
    public float Speed;
    public Text ScoreText;
    public Text WinText;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        // reset score and wintext
        setScoreText();
        WinText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rb.AddForce(new Vector3(horizontal, 0, vertical) * Speed);
    }

    // collision event handler
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);

            score++;
            setScoreText();
        }
        else if(other.gameObject.CompareTag("enemy"))
        {
            other.gameObject.SetActive(false);

            score-=2;
            setScoreText();
        }
    }

    // set score text and wintext
    private void setScoreText()
    {
        ScoreText.text = "Score: " + score.ToString();

        if (score >= 3)
        {
            WinText.text = "YOU WIN!";
        }
    }
}
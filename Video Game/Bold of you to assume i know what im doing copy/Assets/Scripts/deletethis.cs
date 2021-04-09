using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class deletethis : MonoBehaviour
{
  public static deletethis instance;
  public GameObject GameOverText;
  public Text scoreText;
  public bool gameOver = false;
  public float scrollSpeed = -1.5f;
  private int score = 0;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }


        void Update()
        {
            if (gameOver == true && Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        public void BirdScored()
        {
            if (gameOver)
            {
                return;
            }
            score++;
            scoreText.text = "Score: " + score.ToString();
        }

        public void BirdDied()
        {
            GameOverText.SetActive(true);
            gameOver = true;
        }


    public class ScrollingObject : MonoBehaviour
    {
        private Rigidbody2D rb2d;

        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
            rb2d.velocity = new Vector2(GameControl.instance.scrollSpeed, 0);
        }


        void Update()
        {
            if (GameControl.instance.gameOver == true)
            {
                rb2d.velocity = Vector2.zero;
            }
        }
    }


    private BoxCollider2D groundCollider;
    private float groundHorizontalLength;

    // Start is called before the first frame update
    void Start()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -groundHorizontalLength)
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2(groundHorizontalLength * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
}

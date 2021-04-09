using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int health = 3;

    public Text healthText;
    public GameObject heartPickup;
    public GameObject spikes;

    private Rigidbody2D rb2d;
    private Animator anim;

    void Start()
    {
        
    }


    void Update()
    {
        

    }



    void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Pickups"))
		{
			other.gameObject.SetActive(false);

            health++;
        }

		if (other.gameObject.CompareTag("Obstacle"))
		{
            

		}
	}

}




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour
{
    private Animator anim;
    public int forceBack = 3;

    void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<Player>().health -= 1;
        other.gameObject.GetComponent<Animator>().SetTrigger("hit");
        other.gameObject.GetComponent<Player>().transform.position += Vector3.left* Time.deltaTime * forceBack;
    }


}

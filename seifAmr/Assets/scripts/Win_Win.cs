using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_Win : MonoBehaviour
{
    //public AudioClip WIN_1;
   // public AudioClip WIN_2;
    public int value;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player")
        {
            //AudioManeger.instance.RandomizeSfx(WIN_1, WIN_2);
            FindObjectOfType<PlayerStatus>().CollectCoins(value);
            Destroy(this.gameObject);
        }
    }
}

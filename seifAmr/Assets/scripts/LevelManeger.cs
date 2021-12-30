using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManeger : MonoBehaviour
{
    public GameObject currentcheckpoint;
    public Transform player;
    public Transform Enemy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RespawnPlayer()
    {
        FindObjectOfType<playerController>().transform.position = currentcheckpoint.transform.position;
    }
    public void RespawnEnemy()
    {
        Instantiate(Enemy, transform.position, transform.rotation);
    }
}

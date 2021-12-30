using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : EnemyController
{
    private playerController Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, maxSpeed * Time.deltaTime);
    }
}

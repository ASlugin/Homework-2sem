using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearanceOfSCP0871 : MonoBehaviour
{
    [Header("Probabilty of appearance SCP-087-1")]
    public int probability = 50;

    public GameObject scp0871a;
    public GameObject scp0871b;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            System.Random random = new();
            int randomNumber = random.Next(1, 100);
            if (randomNumber <= probability)
            {
                Instantiate(scp0871a, new Vector3(15.75f, 10f, 1f), Quaternion.identity);
                Instantiate(scp0871b, new Vector3(13f, 10f, 3.3f), Quaternion.identity);
            }
        }
    }
}

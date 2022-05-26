using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterProbability : MonoBehaviour
{
    private int probability;

    public GameObject textBox;

    public AppearanceOfSCP0871 scp0871;

    public GameObject canvas;

    void Start()
    {
        Time.timeScale = 0;
    }

    public void StoreProbability()
    {
        probability = Convert.ToInt32(textBox.GetComponent<Text>().text);
        scp0871.probability = probability;
        canvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }
}

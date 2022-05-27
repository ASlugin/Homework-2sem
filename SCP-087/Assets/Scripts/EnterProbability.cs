using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterProbability : MonoBehaviour
{
    private int probability;

    public GameObject player;
    public GameObject cameraPlayer;
    
    public Text numberFloorText;

    public GameObject textBox;

    public AppearanceOfSCP0871 scp0871;

    [Header("UI elements:")]
    public GameObject intro;
    public GameObject timeOnGame;
    public GameObject textFloor;
    public GameObject numberFloor;
    public GameObject dead;

    private Vector3 startPosition;
    private Quaternion startRotation;
    private Quaternion startRotationCamera;

    void Start()
    {
        startPosition =  GameObject.Find("Player").transform.position;
        startRotation = GameObject.Find("Player").transform.rotation;
        startRotationCamera = GameObject.Find("Main Camera").transform.rotation;
        timeOnGame.SetActive(false);
        dead.SetActive(false);
        Time.timeScale = 0;
    }

    public void StoreProbability()
    {
        probability = Convert.ToInt32(textBox.GetComponent<Text>().text);
        if (probability < 0 || probability > 100)
        {
            return;
        }
        numberFloorText.text = "0";
        scp0871.probability = probability;
        intro.SetActive(false);
        timeOnGame.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Retry()
    {
        dead.SetActive(false);
        timeOnGame.SetActive(false);
        intro.SetActive(true);
        scp0871.newSCP0871a.SetActive(false);
        scp0871.newSCP0871b.SetActive(false);
        GameObject.Find("Player").transform.position = startPosition;
        GameObject.Find("Player").transform.rotation = startRotation;
        GameObject.Find("Main Camera").transform.rotation = startRotationCamera;
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{

    float speed;
    bool closeBy;
    Vector3 dir;

    public GameController game;
    public GameObject backWall;
    public GameObject minigame;
    public Slider slider;
    public Text objective;
    
    void Start()
    {
        speed = 3;
        closeBy = false;
        GameObject b =  Instantiate(backWall);
        b.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2);
        slider = minigame.transform.GetChild(0).GetComponent<Slider>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            dir = Vector3.forward * speed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            dir = Vector3.back * speed * Time.deltaTime;
        }
        else
        {
            dir = Vector3.zero;
        }

        transform.position += dir;

        if(closeBy && Input.GetKeyDown(KeyCode.Space))
        {
            if(!minigame.activeSelf)
            {
                minigame.SetActive(true);
                objective.text = "Pick the lock";
            }
            else
            {
                minigame.SetActive(false);
            }
        }
        ///PlaceHolder Condition
        if(minigame.activeSelf && Input.GetMouseButtonDown(0))
        {
           if(slider.value > 45 && slider.value < 55)
           {
                game.Win();    
           }
           else
           {
                game.Lose();
           }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        closeBy = true;
        objective.text = "Press SPACE attempt to pick the lock";
    }

    private void OnTriggerExit(Collider other)
    {
        closeBy = false;
        objective.text = "Walk towards the door";
        minigame.SetActive(false);
    }

}

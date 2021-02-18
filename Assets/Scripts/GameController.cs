using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject minigame;
    public Slider slider;
    public GameObject door;
    public GameObject roomPrefab;
    public GameObject player;
    public Text objective;
    public Text playerSkill;
    float lv;
    float z;
    float difficulty;
    
    void Start()
    {
        door = GameObject.Find("Door");
        lv = 1;
        z = 0;
        slider = minigame.transform.GetChild(0).GetComponent<Slider>();
        difficulty = 1;
    }

    void Update()
    {
        playerSkill.text = "SKILL:" + lv.ToString();
        slider.value += difficulty / lv;
        if(slider.value == 0 || slider.value == 100)
        {
            difficulty *= -1;
        }
    }

    public void Win()
    {
        lv++;
        var room = Instantiate(roomPrefab);
        z += 10;
        room.transform.position = new Vector3(0, 0, z);
        door.transform.position += new Vector3(0, 0, 10);
        minigame.SetActive(false);
        door = GameObject.Find("Door");
        objective.text = "Walk towards the door";
    }

    public void Lose()
    {
        
    }

}

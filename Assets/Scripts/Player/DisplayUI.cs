using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;



public class DisplayUI : MonoBehaviour
{
    public GameObject playerHealth;


    // Update is called once per frame
    void Update()
    {

        PlayerHittableInfo _player = playerHealth.GetComponent<PlayerHittableInfo>();

        Slider _ui = gameObject.GetComponent<Slider>();
        _ui.SetValueWithoutNotify(_player.HP);
    }
}

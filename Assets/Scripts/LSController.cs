using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LSController : MonoBehaviour
{
    public static LSController instance;

    public GameObject levelInfoBox;

    public TMP_Text levelText, actionText;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        AudioManager.instance.PlayMusic(1);
    }




}

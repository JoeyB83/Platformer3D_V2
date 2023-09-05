using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LevelExit : MonoBehaviour
{
    public string levelToLoad;

    private bool exiting;

    public Animator anim;

    public Transform camPos;

    public int numlevels;

    public string[] levels;

    public string finalScreen;


    // Start is called before the first frame update
    void Start()
    {
        numlevels = PlayerPrefs.GetInt("Levels");
        AudioManager.instance.PlayMusic(2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(!exiting)
            {
                exiting = true;

                anim.SetBool("active", true);

                numlevels++;

                PlayerPrefs.SetInt("Levels", numlevels);

                AudioManager.instance.PlayMusic(4);

                AudioManager.instance.PlaySFX(8);

                if (numlevels >= levels.Length)
                {
                    LevelManager.instance.EndLevel(finalScreen);

                    FindObjectOfType<CameraController>().endCamPos = camPos;

                }
                else
                {
                    LevelManager.instance.EndLevel(levelToLoad);

                    FindObjectOfType<CameraController>().endCamPos = camPos;
                }               
            }
        }
    }
}

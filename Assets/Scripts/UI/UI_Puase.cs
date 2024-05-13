using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Puase : MonoBehaviour
{

    [SerializeField]
    GameObject title;
    [SerializeField]
    GameObject main;

    private void OnEnable()
    {
        Time.timeScale = 0;
    }
    private void OnDisable()
    {
        Time.timeScale = 1;   
    }

    public void ReStart(Player player)
    {
        gameObject.SetActive(false);
        player.GameStart();
    }

    public void GoSelect()
    {

        gameObject.SetActive(false);
        main.SetActive(false);
        title.SetActive(true);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class main_menu : MonoBehaviour
{
    public Button btn_levels,btn_free_snake_game,btn_exit;
    // Start is called before the first frame update
    void Start()
    {
        btn_levels.onClick.AddListener(()=>{
            SceneManager.LoadScene("levels");
        }); 

        btn_free_snake_game.onClick.AddListener(()=>{
            SceneManager.LoadScene("Snake_free_game");
        }); 


        btn_exit.onClick.AddListener(()=>{
            Application.Quit();
        });   
    }

    // Update is called once per frame
    void Update()
    {
    }

}

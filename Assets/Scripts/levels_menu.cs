using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levels_menu : MonoBehaviour
{
    
    public Button btn_level_1,btn_level_2,btn_level_3,btn_level_4,btn_level_5,btn_level_6,btn_back_main;
    public Text txt_btn_level_1,txt_btn_level_2,txt_btn_level_3,txt_btn_level_4,txt_btn_level_5,txt_btn_level_6;
    // Start is called before the first frame update
    void Start()
    {

        int snake_score_1=PlayerPrefs.GetInt("snake_score_1",0);
        int snake_score_1_done=PlayerPrefs.GetInt("snake_score_1_done",0);
        
        int snake_score_2=PlayerPrefs.GetInt("snake_score_2",0);
        int snake_score_2_done=PlayerPrefs.GetInt("snake_score_2_done",0);
        
        int snake_score_3=PlayerPrefs.GetInt("snake_score_3",0);
        int snake_score_3_done=PlayerPrefs.GetInt("snake_score_3_done",0);
        
        int snake_score_4=PlayerPrefs.GetInt("snake_score_4",0);
        int snake_score_4_done=PlayerPrefs.GetInt("snake_score_4_done",0);
        
        int snake_score_5=PlayerPrefs.GetInt("snake_score_5",0);
        int snake_score_5_done=PlayerPrefs.GetInt("snake_score_5_done",0);
        
        int snake_score_6=PlayerPrefs.GetInt("snake_score_6",0);
        int snake_score_6_done=PlayerPrefs.GetInt("snake_score_6_done",0);

        if(snake_score_1_done==1){

            ColorBlock colors = btn_level_1.colors;
            colors.highlightedColor = new Color32(22, 255, 1, 255);
            colors.normalColor = new Color32(22, 255, 1, 255);
            btn_level_1.colors = colors;
            btn_level_2.interactable=true;
        }

        if(snake_score_2_done==1){
            ColorBlock colors = btn_level_2.colors;
            colors.highlightedColor = new Color32(22, 255, 1, 255);
            colors.normalColor = new Color32(22, 255, 1, 255);
            btn_level_2.colors = colors;
            btn_level_3.interactable=true;
        }

        if(snake_score_3_done==1){
            ColorBlock colors = btn_level_3.colors;
            colors.highlightedColor = new Color32(22, 255, 1, 255);
            colors.normalColor = new Color32(22, 255, 1, 255);
            btn_level_3.colors = colors;
            btn_level_4.interactable=true;
        }

        if(snake_score_4_done==1){
            ColorBlock colors = btn_level_4.colors;
            colors.highlightedColor = new Color32(22, 255, 1, 255);
            colors.normalColor = new Color32(22, 255, 1, 255);
            btn_level_4.colors = colors;
            btn_level_5.interactable=true;
        }
        
        if(snake_score_5_done==1){
            ColorBlock colors = btn_level_5.colors;
            colors.highlightedColor = new Color32(22, 255, 1, 255);
            colors.normalColor = new Color32(22, 255, 1, 255);
            btn_level_5.colors = colors;
            btn_level_6.interactable=true;
        }
        
        if(snake_score_6_done==1){
            ColorBlock colors = btn_level_6.colors;
            colors.highlightedColor = new Color32(22, 255, 1, 255);
            colors.normalColor = new Color32(22, 255, 1, 255);
            btn_level_6.colors = colors;
        }

        btn_level_1.onClick.AddListener(()=>{
            SceneManager.LoadScene("Snake_1");
        });

        btn_level_2.onClick.AddListener(()=>{
            SceneManager.LoadScene("Snake_2");
        });
        
        btn_level_3.onClick.AddListener(()=>{
            SceneManager.LoadScene("Snake_3");
        });

        btn_level_4.onClick.AddListener(()=>{
            SceneManager.LoadScene("Snake_4");
        });
        
        btn_level_5.onClick.AddListener(()=>{
            SceneManager.LoadScene("Snake_5");
        });
        
        btn_level_6.onClick.AddListener(()=>{
            SceneManager.LoadScene("Snake_6");
        });

        btn_back_main.onClick.AddListener(()=>{
            SceneManager.LoadScene("main_menu");
        });
        txt_btn_level_1.text="ﻝﻭﺍ ﻪﻠﺣﺮﻣ"+"\n"+snake_score_1.ToString()+"/10 ";
        
        txt_btn_level_2.text="ﻢﻣﻭﺩ ﻪﻠﺣﺮﻣ"+"\n"+snake_score_2.ToString()+"/20 ";
        
        txt_btn_level_3.text="ﻢﻣﻭﺩ ﻪﻠﺣﺮﻣ"+"\n"+snake_score_3.ToString()+"/30 ";
        
        txt_btn_level_4.text="ﻢﻣﻭﺩ ﻪﻠﺣﺮﻣ"+"\n"+snake_score_4.ToString()+"/20 ";
        
        txt_btn_level_5.text="ﻢﻣﻭﺩ ﻪﻠﺣﺮﻣ"+"\n"+snake_score_5.ToString()+"/30 ";
        
        txt_btn_level_6.text="ﻢﻣﻭﺩ ﻪﻠﺣﺮﻣ"+"\n"+snake_score_5.ToString()+"/35 ";
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}

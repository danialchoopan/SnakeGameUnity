using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class snake : MonoBehaviour
{
    
    public Transform segmentPrefab;
    
    private List<Transform> _segments;
    private Vector2 _direction;
    public GameObject gameOverPage,PanelStart;
    public Button btn_start,btn_home_menu,btn_reset_game,btn_resume,btn_back_to_levels;
    private bool gameIsActive;

    //food cs code

    public int player_point=0;

    public Text game_score;

    public int gameLevel;

    public Button btn_win_next_level,btn_back_home_menu_win;
    public GameObject win_panel,pause_panel;

    bool pause_toggle=false;

    // Start is called before the first frame update
    void Start()
    {
        _segments=new List<Transform>();
        _segments.Add(this.transform);
        gameSpeed();

        //btn events
        
        btn_start.onClick.AddListener(()=>{
            StartGame();
            // btn_start.SetActive(false);
            PanelStart.SetActive(false);
            gameIsActive=true;
            gameSpeed();
        });
        
        btn_reset_game.onClick.AddListener(()=>{
            // RestartGame();
            gameOverPage.SetActive(false);
            PanelStart.SetActive(true);
            gameIsActive=false;
        });
        btn_home_menu.onClick.AddListener(()=>{
            SceneManager.LoadScene("main_menu");
        });

        btn_back_home_menu_win.onClick.AddListener(()=>{
            SceneManager.LoadScene("main_menu");
        });
        btn_resume.onClick.AddListener(()=>{
            pause_panel.SetActive(false);
            gameSpeed();
        });
        btn_back_to_levels.onClick.AddListener(()=>{
            SceneManager.LoadScene("levels");
        });
    }

    // Update is called once per frame
    void Update()
    {
        if(gameIsActive){
            if(Input.GetKeyDown(KeyCode.W)){
                _direction=Vector2.up;
            } else if(Input.GetKeyDown(KeyCode.S)){
                _direction=Vector2.down;
            }else if(Input.GetKeyDown(KeyCode.A)){
                _direction=Vector2.left;
            }else if(Input.GetKeyDown(KeyCode.D)){
                _direction=Vector2.right;
            }else if(Input.GetKeyDown(KeyCode.Escape)){
                if(pause_toggle){
                    pause_toggle=!pause_toggle;
                    pause_panel.SetActive(false);
                    gameSpeed();
                }else{
                    pause_toggle=!pause_toggle;
                    pause_panel.SetActive(true);
                    stopGame();
                }
            }
        }
    }

    private void FixedUpdate(){
        for (int i = _segments.Count-1; i > 0; i--)
        {
            _segments[i].position=_segments[i-1].position;
        }
        
        this.transform.position=new Vector3(
            Mathf.Round(this.transform.position.x+_direction.x),
            Mathf.Round(this.transform.position.y+_direction.y),
            0.0f
        );

    }

    private void Grow(){
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position=_segments[_segments.Count-1].position;
        _segments.Add(segment);
    }

    private void ResetState(){
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }        
        _segments.Clear();
        _segments.Add(this.transform);

        this.transform.position=Vector3.zero;

        //stop the game 
        Time.timeScale = 0;
        player_point=0;


         switch(gameLevel){
                //level 1
                case 1:
                    game_score.text="0/10 : ﺎﻤﺷ ﺯﺎﯿﺘﻣﺍ";
                break;
                //level 2
                case 2:
                    game_score.text="0/20 : ﺎﻤﺷ ﺯﺎﯿﺘﻣﺍ";
                break;
                //level 3
                case 3:
                    game_score.text="0/30 : ﺎﻤﺷ ﺯﺎﯿﺘﻣﺍ";
                break;
                //level 4
                case 4:
                    game_score.text="0/20 : ﺎﻤﺷ ﺯﺎﯿﺘﻣﺍ";
                break;
                //level 5
                case 5:
                    game_score.text="0/30 : ﺎﻤﺷ ﺯﺎﯿﺘﻣﺍ";
                break;
                //level 6
                case 6:
                    game_score.text="0/35 : ﺎﻤﺷ ﺯﺎﯿﺘﻣﺍ";
                break;
            }
    }
    
    private void OnTriggerEnter2D(Collider2D other){
         switch(gameLevel){
                //level 1
                case 1:
                    game_score.text=((int)player_point).ToString()+"/10 : ﺎﻤﺷ ﺯﺎﯿﺘﻣﺍ";
                    PlayerPrefs.SetInt("snake_score_1",player_point);
                    if(player_point>=10){
                        PlayerPrefs.SetInt("snake_score_1_done",1);
                        // game_score.text="شما برنده شده اید";
                        //show lose panel 
                        win_panel.SetActive(true);

                        //next level                         
                        btn_win_next_level.onClick.AddListener(()=>{
                            SceneManager.LoadScene("Snake_2");
                        });

                        //stop the game 
                        Time.timeScale = 0;
                        // game_score.text="شما برنده شده اید";
                    }
                break;
                //level 2
                case 2:
                    game_score.text=((int)player_point).ToString()+"/20 : ﺎﻤﺷ ﺯﺎﯿﺘﻣﺍ";
                    PlayerPrefs.SetInt("snake_score_2",player_point);
                    if(player_point>=20){
                        // game_score.text="شما برنده شده اید";
                        
                        PlayerPrefs.SetInt("snake_score_2_done",1);
                        
                        //show lose panel 
                        win_panel.SetActive(true);
                        
                         //next level                         
                        btn_win_next_level.onClick.AddListener(()=>{
                            SceneManager.LoadScene("Snake_3");
                        });

                        //stop the game 
                        Time.timeScale = 0;

                        
                    }
                    
                break;
                //level 3
                case 3:
                    game_score.text=((int)player_point).ToString()+"/30 : ﺎﻤﺷ ﺯﺎﯿﺘﻣﺍ";
                    PlayerPrefs.SetInt("snake_score_3",player_point);
                    if(player_point>=30){
                        PlayerPrefs.SetInt("snake_score_3_done",1);
                        //show lose panel 
                        win_panel.SetActive(true);
                        //next level                         
                        btn_win_next_level.onClick.AddListener(()=>{
                            SceneManager.LoadScene("Snake_4");
                        });
                        //stop the game 
                        Time.timeScale = 0;
                    }
                break;
                
                //level 4
                case 4:
                    game_score.text=((int)player_point).ToString()+"/20 : ﺎﻤﺷ ﺯﺎﯿﺘﻣﺍ";
                    PlayerPrefs.SetInt("snake_score_4",player_point);
                    if(player_point>=20){
                        PlayerPrefs.SetInt("snake_score_4_done",1);
                        //show lose panel 
                        win_panel.SetActive(true);
                        //next level                         
                        btn_win_next_level.onClick.AddListener(()=>{
                            SceneManager.LoadScene("Snake_5");
                        });
                        //stop the game 
                        Time.timeScale = 0;
                    }
                break;
                
                //level 5
                case 5:
                    game_score.text=((int)player_point).ToString()+"/30 : ﺎﻤﺷ ﺯﺎﯿﺘﻣﺍ";
                    PlayerPrefs.SetInt("snake_score_5",player_point);
                    if(player_point>=30){
                        PlayerPrefs.SetInt("snake_score_5_done",1);
                        //show lose panel 
                        win_panel.SetActive(true);
                        //next level                         
                        btn_win_next_level.onClick.AddListener(()=>{
                            SceneManager.LoadScene("Snake_6");
                        });
                        //stop the game 
                        Time.timeScale = 0;
                    }
                break;
                
                //level 6
                case 6:
                    game_score.text=((int)player_point).ToString()+"/35 : ﺎﻤﺷ ﺯﺎﯿﺘﻣﺍ";
                    PlayerPrefs.SetInt("snake_score_6",player_point);
                    if(player_point>=35){
                        PlayerPrefs.SetInt("snake_score_6_done",1);
                        //show lose panel 
                        win_panel.SetActive(true);
                        btn_win_next_level.enabled=false;
                        
                        //stop the game 
                        Time.timeScale = 0;
                    }
                break;
            }
            if(other.tag=="Food"){
                Grow();
                player_point++;
            }
            if(gameLevel==1 || gameLevel==2 || gameLevel==3){
                
                if (other.tag=="obstacle"){
                    gameOverPage.SetActive(true);
                    ResetState();
                }
            } else {
                // if(other.tag=="Food"){
                //     Grow();
                //     player_point++;
                // }
                if (other.tag=="obstacle" || other.tag=="snake_tail"){
                    gameOverPage.SetActive(true);
                    ResetState();
                }
            }

    }
    
    public void StartGame(){
        _direction=Vector2.right;
    }
    private void stopGame(){
        Time.timeScale = 0;
    }
    private void gameSpeed(){
        if(gameLevel>0 && gameLevel<=4){
            Time.timeScale = 0.8f;
        }else{
            Time.timeScale = 0.9f;
        }

    }
}

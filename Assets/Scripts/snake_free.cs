using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class snake_free : MonoBehaviour
{
    
    public GameObject start_panel,end_panel,pause_panel;
    public Button btn_start,btn_end_game,btn_resume_game,btn_back_home;
    public Text txt_best_score,txt_game_score,txt_best_score_end_panel;
    public Transform segmentPrefab;

    //private
    private bool gameIsActive;
    private bool pause_toggle=false;
    private List<Transform> _segments;
    private Vector2 _direction;
    private int player_point=0;
    private int base_score=0;

    // Start is called before the first frame update
    void Start()
    {
        _segments=new List<Transform>();
        _segments.Add(this.transform);
        gameSpeed();

        btn_start.onClick.AddListener(()=>{
            StartGame();
            start_panel.SetActive(false);
            gameIsActive=true;
            gameSpeed();
        });
        btn_resume_game.onClick.AddListener(()=>{
            pause_panel.SetActive(false);
            gameSpeed();
        });
        btn_back_home.onClick.AddListener(()=>{
            SceneManager.LoadScene("levels");
        });
        btn_end_game.onClick.AddListener(()=>{
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
    private void OnTriggerEnter2D(Collider2D other){
        base_score=PlayerPrefs.GetInt("snake_best_score",0);
        txt_game_score.text=((int)player_point).ToString()+" : ﺎﻤﺷ ﺯﺎﯿﺘﻣﺍ";
        txt_best_score.text=((int)base_score).ToString()+" : ﺯﺎﯿﺘﻣﺍ ﻦﯾﺮﺘﻬﺑ";
        txt_best_score_end_panel.text=((int)base_score).ToString()+" : ﺯﺎﯿﺘﻣﺍ ﻦﯾﺮﺘﻬﺑ";
        
        if(player_point>=base_score){
            PlayerPrefs.SetInt("snake_best_score",player_point);
        }
        
        if(other.tag=="Food"){
            Grow();
            player_point++;
        }
        if (other.tag=="obstacle"){
            end_panel.SetActive(true);
            stopGame();
        }
                    
    }
    
    private void Grow(){
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position=_segments[_segments.Count-1].position;
        _segments.Add(segment);
    }

    
    public void StartGame(){
        _direction=Vector2.right;
    }
    private void stopGame(){
        Time.timeScale = 0;
    }
    private void gameSpeed(){
        Time.timeScale = 0.9f;
    }
}

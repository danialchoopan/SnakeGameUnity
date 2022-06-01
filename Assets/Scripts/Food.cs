using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;

    // Start is called before the first frame update
    void Start()
    {
        RandomizePosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void RandomizePosition(){
        Bounds bounds=this.gridArea.bounds;
        float x=Random.Range(bounds.min.x,bounds.max.x);
        float y=Random.Range(bounds.min.y,bounds.max.y);
        this.transform.position=new Vector3(Mathf.Round(x),Mathf.Round(y),0.0f);

    } 

    private void OnTriggerEnter2D(Collider2D other){
        RandomizePosition();
    }
}

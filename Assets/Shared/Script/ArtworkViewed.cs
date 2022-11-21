using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtworkViewed : MonoBehaviour
{
    private new Transform camera;
    GameObject ultReconocido = null;
    private float t_teleport; 
    private float t_teleportR; 
    private float t_teleportL; 
    
    // Start is called before the first frame update
    void Start()
    {
        camera = transform.Find("Main Camera");
        t_teleport = 3;
        t_teleportR = 3;
        t_teleportL = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(camera.transform.position,camera.forward*60,Color.red);
        RaycastHit hit;
        //////////////////////////////////////CENTER//////////////////////////////////////
        if(Physics.Raycast(camera.transform.position,camera.forward,out hit,60,LayerMask.GetMask("Art"))){
            //Debug.Log(hit.transform.name);
            Timer();
            Debug.Log(t_teleport);
            if (t_teleport <= 0){      
                Teleport(hit.transform);
            }
        }
        else{
            ArtworkNotLooked();
            t_teleport = 3;
        }
        //////////////////////////////////////RIGHT//////////////////////////////////////
        if(Physics.Raycast(camera.transform.position,camera.forward,out hit,60,LayerMask.GetMask("ArtRight"))){
            //Debug.Log(hit.transform.name);
            TimerRight();
            Debug.Log(t_teleportR);
            if (t_teleportR <= 0){     
                TeleportRight(hit.transform);
            }
        }
        else{
            ArtworkNotLooked();
            t_teleportR = 3;
        }
        //////////////////////////////////////LEFT//////////////////////////////////////
        if(Physics.Raycast(camera.transform.position,camera.forward,out hit,60,LayerMask.GetMask("ArtLeft"))){
            //Debug.Log(hit.transform.name);
            TimerLeft();
            Debug.Log(t_teleportL);
            if (t_teleportL <= 0){      
                TeleportLeft(hit.transform);
            }
        }
        else{
            ArtworkNotLooked();
            t_teleportL = 3;
        }
    }

    void Teleport(Transform pointTP){
        ultReconocido = pointTP.gameObject;
        transform.position = new Vector3(ultReconocido.transform.position.x,
                                               ultReconocido.transform.position.y,
                                               ultReconocido.transform.position.z - 3);
    }
    void TeleportRight(Transform pointTP){
        ultReconocido = pointTP.gameObject;
        transform.position = new Vector3(ultReconocido.transform.position.x - 3,
                                               ultReconocido.transform.position.y,
                                               ultReconocido.transform.position.z);
        
    }
    void TeleportLeft(Transform pointTP){
        ultReconocido = pointTP.gameObject;
        transform.position = new Vector3(ultReconocido.transform.position.x + 3,
                                               ultReconocido.transform.position.y,
                                               ultReconocido.transform.position.z);
    }

    void Timer(){
        t_teleport -= 1*Time.deltaTime;
    }
    void TimerRight(){
        t_teleportR -= 1*Time.deltaTime;
    }
    void TimerLeft(){
        t_teleportL -= 1*Time.deltaTime;
    }
    void ArtworkNotLooked(){
        if(ultReconocido){
            ultReconocido = null;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corner : MonoBehaviour
{
    public GameObject source;
    public string sourdir;
    public GameObject newlocal;
    public string newdir;
    
    public void Setup(GameObject sour, string sdir, string ndir){
        print(sdir + ndir);
        if(sdir == "n"){
            if(ndir == "w"){
                transform.rotation = Quaternion.Euler(0f,0f,0f);
                transform.localScale = new Vector3(-1f,1f,1f);
            } else if(ndir == "e"){
                transform.rotation = Quaternion.Euler(0f,0f,0f);
                transform.localScale = new Vector3(1f,1f,1f);
            } else{
                print("Failed");
            }
        } else if(sdir == "s"){
            if(ndir == "w"){
                transform.rotation = Quaternion.Euler(0f,0f,180f);
                transform.localScale = new Vector3(1f,1f,1f);
            } else if(ndir == "e"){
                transform.rotation = Quaternion.Euler(0f,0f,180f);
                transform.localScale = new Vector3(-1f,1f,1f);
            } else{
                print("Failed");
            }
        } else if(sdir == "e"){
            if(ndir == "n"){
                transform.rotation = Quaternion.Euler(0f,0f,90f);
                transform.localScale = new Vector3(1f,-1f,1f);
            } else if(ndir == "s"){
                transform.rotation = Quaternion.Euler(0f,0f,90f);
                transform.localScale = new Vector3(1f,1f,1f);
            } else{
                print("Failed");
            }
        } else if(sdir == "w"){
           if(ndir == "n"){
                transform.rotation = Quaternion.Euler(0f,0f,270f);
                transform.localScale = new Vector3(1f,1f,1f);
            } else if(ndir == "s"){
                transform.rotation = Quaternion.Euler(0f,0f,270f);
                transform.localScale = new Vector3(1f,-1f,1f);
            } else{
                print("Failed");
            }
        } else{
            print("Failed");
        }
    }
}

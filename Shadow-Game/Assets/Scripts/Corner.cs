using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corner : MonoBehaviour
{
    public GameObject source;
    public string sdir;
    public Transform newlocal;
    public string ndir;
    
    public Transform Setup(GameObject sour, string sourdir, string newdir){
        print(sdir + ndir);
        source = sour;
        sdir = sourdir;
        ndir = newdir;
        DirMap();
        return newlocal;
    }

    public void DirMap(){
        if(sdir == "n"){
            if(ndir == "w"){//working
                transform.rotation = Quaternion.Euler(0f,0f,0f);
                transform.localScale = new Vector3(01f,1f,1f);
            } else if(ndir == "e"){//working
                transform.rotation = Quaternion.Euler(0f,0f,0f);
                transform.localScale = new Vector3(-1f,1f,1f);
            } else{
                print("Failed");
            }
        } else if(sdir == "s"){
            if(ndir == "w"){//working
                transform.rotation = Quaternion.Euler(0f,0f,0f);
                transform.localScale = new Vector3(1f,-1f,1f);
            } else if(ndir == "e"){//working
                transform.rotation = Quaternion.Euler(0f,0f,0f);
                transform.localScale = new Vector3(-1f,-1f,1f);
            } else{
                print("Failed");
            }
        } else if(sdir == "e"){
            if(ndir == "n"){
                transform.rotation = Quaternion.Euler(0f,0f,90f);
                transform.localScale = new Vector3(-1f,-1f,1f);
            } else if(ndir == "s"){
                transform.rotation = Quaternion.Euler(0f,0f,90f);
                transform.localScale = new Vector3(1f,-1f,1f);
            } else{
                print("Failed");
            }
        } else if(sdir == "w"){
           if(ndir == "s"){//working
                transform.rotation = Quaternion.Euler(0f,0f,90f);
                transform.localScale = new Vector3(1f,1f,1f);
            } else if(ndir == "n"){//working
                transform.rotation = Quaternion.Euler(0f,0f,90f);
                transform.localScale = new Vector3(-1f,1f,1f);
            } else{
                print("Failed");
            }
        } else{
            print("Failed");
        }
    }
}

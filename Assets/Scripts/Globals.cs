using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    private int NPCQuantity = 0;

    public void addNPC(int n){
        NPCQuantity += n;
    }
    
    public int getQuantity(){
        return NPCQuantity;
    }
}

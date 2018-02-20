using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor.Experimental.UIElements;
using UnityEngine;


public class playerInventory : MonoBehaviour {
    public static Dictionary<string, int> inventory = new Dictionary<string, int>();
    //public static Dictionary<int, hotbar> selectedItems = new Dictionary<int, hotbar>();
    public static hotbar selectedItem;

    private int scroll;
    

    //public static int fireFlies = 0;
    //public static int lampPosts = 0;
    //public static int 

    // Use this for initialization
    void Start() {
        
        string[] elements = Enum.GetNames(typeof(hotbar));

        for (int i = 0; i < elements.Length; i++) { 
        
               inventory.Add(elements[i], 0);
        
        }


    }

    // Update is called once per frame
    void Update() {
    
        string[] elements = Enum.GetNames(typeof(hotbar));
        
    if (Input.GetKeyDown(KeyCode.E)) {

        scroll++;
        if (scroll >= elements.Length ) {

            scroll = 0;

        }


    }

        if (Input.GetKeyDown(KeyCode.Q)) {

            scroll--;
            
            if (scroll < 0) {

                scroll = elements.Length - 1;

            }
            
            

        }

        selectedItem = (hotbar)scroll;
        Debug.Log(selectedItem.ToString());



    }
}

public enum hotbar { 

    tool,
    seeds,
    fireFlies,
    jars,
    
    
    

}
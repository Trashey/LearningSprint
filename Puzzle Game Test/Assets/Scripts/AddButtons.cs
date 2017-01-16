using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButtons : MonoBehaviour {

    //Simple script to add more buttons :D

    //SerializeField makes private variables visible in the inspector 
    [SerializeField]
    private Transform puzzleField;

    [SerializeField]
    private GameObject btn;


    //Awake is used instead of start in order to setup the components on the object it's assigned to.
    void Awake()
    {
        for (int i = 0; i < 8; i++)
        {
            //create the button
            GameObject button = Instantiate(btn);
            //name will be numbers going from 0 to i
            button.name = "" + i;
            //sets the parent to puzzlefield, we dont want world position to stay, so set to false
            button.transform.SetParent(puzzleField, false);
        }
    }

	//// Use this for initialization
	//void Start () {
		
	//}	
	//// Update is called once per frame
	//void Update () {
		
	//}
}

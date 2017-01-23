using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSlots : MonoBehaviour {

    //Simple script to add slots that can move :D

    //SerializeField makes private variables visible in the inspector 
    [SerializeField]
    private Transform puzzleField;

    [SerializeField]
    private GameObject slot;

   public int button_amount;

    //Awake is used instead of start in order to setup the components on the object it's assigned to.
    void Awake()
    {
        StartButtons();
     
    }

    public void StartButtons()
    {
        button_amount = 3;
        for (int i = 0; i < button_amount; i++)
        {
            //create the button
            GameObject button = Instantiate(slot);
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

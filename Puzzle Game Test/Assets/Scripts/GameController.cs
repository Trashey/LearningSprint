using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour {

    [SerializeField]
    //background image sprite
    private Sprite bgImage;

    public Sprite[] puzzles;

    public List<Sprite> gamePuzzles = new List<Sprite>();
    //create list of buttons
    public List<Button> btns = new List<Button>();

    private bool firstGuess, secondGuess;

    private int countGuesses;
    private int countCorrectGuesses;
    private int GameGuesses;

    private int firstGuessIndex, secondGuessIndex;

    private string firstGuessPuzzle, secondGuessPuzzle;

    void Awake()
    {
        //Loads all the sprites in the path Candy
        puzzles = Resources.LoadAll<Sprite>("Sprites/Candy");
    }

	void Start()
    {
        GetButtons();
        AddListeners();
        AddGamePuzzles();
        Shuffle(gamePuzzles);

        //amount of correct guess to win the game
        GameGuesses = gamePuzzles.Count / 2;
    }

    void GetButtons()
    {
        //get game objects with tag 
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");

        
        for (int i = 0; i < objects.Length; i++)
        {
            //add butons to list 
            btns.Add(objects[i].GetComponent<Button>());
            //add sprite to image
            btns[i].image.sprite = bgImage;
         }

    }

   //Get the count of all the buttons on screen, divide that number by 2 to obtain duplicate sprites for a matching game
    void AddGamePuzzles()
    {
        int looper = btns.Count;
        int index = 0;

        for (int i = 0; i < looper; i++)
        {
            
            if (index == looper / 2)
            {
                index = 0;
            }

            gamePuzzles.Add(puzzles[index]);
            index++;
        }
    }

    void AddListeners()
    {
        //for (int i = 0; i < btns.Count; i++)
        //{

        //}

        //This is a faster way of going through the buttons. Above is the same thing but a for loop
        foreach (Button btn in btns)
        {
            //Add a listener to our buttons.
            btn.onClick.AddListener(() => PickAPuzzle());
        }
    }

    public void PickAPuzzle()
    {
        //a really damn crazy way of getting the clicked game objects's specific name
       // string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        if (!firstGuess)
        {
            //set to true so we don't click the same button again
            firstGuess = true;
            //getting the index of the button
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            //store the name of the first clicked button/image
            firstGuessPuzzle = gamePuzzles[firstGuessIndex].name;

            //set the button to a different sprite
            btns[firstGuessIndex].image.sprite = gamePuzzles[firstGuessIndex];
        }
        else if (!secondGuess)
        {
            secondGuess = true;            
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            secondGuessPuzzle = gamePuzzles[secondGuessIndex].name;
            btns[secondGuessIndex].image.sprite = gamePuzzles[secondGuessIndex];
            countGuesses++;
            StartCoroutine(CheckIfThePuzzlesMatch());


            //if (firstGuessPuzzle == secondGuessPuzzle)
            //{
            //    Debug.Log("The Puzzles Match!!");
            //}
            //else
            //{
            //    Debug.Log("The Puzzles DON'T Match");
            //}

        }        
        //Debug.Log("You are clicking a button named " + name);
    }

    
    IEnumerator CheckIfThePuzzlesMatch()
    {
        //wait for x amount of seconds
        yield return new WaitForSeconds(1f);

        if (firstGuessPuzzle == secondGuessPuzzle){
            yield return new WaitForSeconds(.5f);

            //make the buttons that were correctly clicked not interactable anymore
            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;

            //set the color to blank
            btns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);

            CheckIfTheGameIsFinished();
        }

        else
        {
            yield return new WaitForSeconds(.5f);

            //if wrong answer, switch images back to background image
            btns[firstGuessIndex].image.sprite = bgImage;
            btns[secondGuessIndex].image.sprite = bgImage;
        }

        yield return new WaitForSeconds(.5f);

        firstGuess = false;
        secondGuess = false;
    }

    void CheckIfTheGameIsFinished()
    {
        countCorrectGuesses++;
        if(countCorrectGuesses == GameGuesses)
        {
            Debug.Log("Game Finished");
            Debug.Log("If took you " + countGuesses + " many guess(es) to finish the game");
        }
    }


    //Shuffle up the order of the sprites
    void Shuffle(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            // return random number
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
        
    }



}

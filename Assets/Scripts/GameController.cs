using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private string turn = "Player 1's Turn";
    
    private Dictionary<string, int> spots = new(){{"0", 0},{"1", 0},{"2", 0}, {"3", 0}, {"4", 0},
                                                  {"5", 0}, {"6", 0}, {"7", 0}, {"8", 0}};



    public GameObject menu;
    public TextMeshProUGUI menuText;
    private int turnCount = 1;
    public TextMeshProUGUI turnText;

    private int count = 0;
    private List<string> temp = new();

    public GameObject topRowWin;
    public GameObject botRowWin;
    public GameObject midRowWin;
    public GameObject leftColWin;
    public GameObject midColWin;
    public GameObject rightColWin;
    public GameObject rightDiagWin;
    public GameObject leftDiagWin;
    public GameObject[] buttonArray;
    private bool winner = false;
    private bool canPress = true;
    // Start is called before the first frame update
    void Start()
    {
        turnText.text = turn;
    }

    // Update is called once per frame
    void Update()
    {
        //if(turnCount % 3 == 0)
        win();
        if(menu.activeSelf == true && canPress == true){
            foreach(GameObject button in buttonArray){
                button.GetComponent<Button>().enabled = !button.GetComponent<Button>().enabled;
            }
            canPress = false;
        }

    }

    public void drawImg(){
        if(SceneManager.GetActiveScene().name == "PVP_Scene"){
            if(turn == "Player 1's Turn"){
                //StartCoroutine(FadeTextToFullAlpha(1f, turnText));
                StartCoroutine(FadeTextToZeroAlpha(2.5f, turnText));
                string buttonName = EventSystem.current.currentSelectedGameObject.name;
                GameObject button = GameObject.Find(buttonName);
                if(button.transform.GetChild(0).gameObject.activeSelf == false){
                    button.transform.GetChild(1).gameObject.SetActive(true);
                    spots[buttonName] = 1;
                    //Debug.Log(buttonName + ": " + spots[buttonName]);
                    //Debug.Log(spots["1"]);
                    turnCount++;
                    turn = "Player 2's Turn";
                    turnText.text = turn;
                }

            }
            if(turn == "Player 2's Turn"){
                StartCoroutine(FadeTextToZeroAlpha(2.5f, turnText));
                string buttonName = EventSystem.current.currentSelectedGameObject.name;
                GameObject button = GameObject.Find(buttonName);
                if(button.transform.GetChild(1).gameObject.activeSelf == false){
                    button.transform.GetChild(0).gameObject.SetActive(true);
                    spots[buttonName] = 2;
                    //Debug.Log(spots[buttonName]);
                    turnCount++;
                    turn = "Player 1's Turn";
                    turnText.text = turn;
                }

            }
        }
        if(SceneManager.GetActiveScene().name == "PVC_Scene"){
            if(turn == "Player 1's Turn"){
                //StartCoroutine(FadeTextToFullAlpha(1f, turnText));
                StartCoroutine(FadeTextToZeroAlpha(2.5f, turnText));
                string buttonName = EventSystem.current.currentSelectedGameObject.name;
                GameObject button = GameObject.Find(buttonName);
                if(button.transform.GetChild(0).gameObject.activeSelf == false){
                    button.transform.GetChild(1).gameObject.SetActive(true);
                    spots[buttonName] = 1;
                    turnCount++;
                    turn = "Player 2's Turn";
                    turnText.text = turn;
                }
            }
            if(turn == "Player 2's Turn" && winner == false){
                StartCoroutine(FadeTextToZeroAlpha(2.5f, turnText));
                int spotToChoose = UnityEngine.Random.Range(0, 9);
                Debug.Log(spotToChoose);
                TryToDraw:
                    if(spots[spotToChoose.ToString()] == 0){
                        buttonArray[spotToChoose].transform.GetChild(0).gameObject.SetActive(true);
                        spots[spotToChoose.ToString()] = 2;
                    }
                    else if(CheckDictionary(spots)){
                        turn = "Player 1's Turn";
                    }
                    else{
                        spotToChoose = UnityEngine.Random.Range(0, 9);
                        goto TryToDraw;
                    }
                turn = "Player 1's Turn";
            }
        }
    }



    public void win(){
    //PLAYER 1 WINS
        if(spots["0"] == 1 && spots["1"] == 1 && spots["2"] == 1){
            menuText.text = "Player 1 Wins!!!";
            menu.SetActive(true);
            winner = true;    
            topRowWin.SetActive(true);
        }
        else if(spots["3"] == 1 && spots["4"] == 1 && spots["5"] == 1){
            menuText.text = "Player 1 Wins!!!";
            menu.SetActive(true);
            winner = true;
            midRowWin.SetActive(true);
        }
        else if(spots["6"] == 1 && spots["7"] == 1 && spots["8"] == 1){
            menuText.text = "Player 1 Wins!!!";
            menu.SetActive(true);
            winner = true;
            botRowWin.SetActive(true);
        }
        else if(spots["0"] == 1 && spots["3"] == 1 && spots["6"] == 1){
            menuText.text = "Player 1 Wins!!!";
            menu.SetActive(true);
            winner = true;
            leftColWin.SetActive(true);
        }
        else if(spots["1"] == 1 && spots["4"] == 1 && spots["7"] == 1){
            menuText.text = "Player 1 Wins!!!";
            menu.SetActive(true);
            winner = true;
            midColWin.SetActive(true);
        }
        else if(spots["2"] == 1 && spots["5"] == 1 && spots["8"] == 1){
            menuText.text = "Player 1 Wins!!!";
            menu.SetActive(true);
            winner = true;
            rightColWin.SetActive(true);
        }
        else if(spots["0"] == 1 && spots["4"] == 1 && spots["8"] == 1){
            menuText.text = "Player 1 Wins!!!";
            menu.SetActive(true);
            winner = true;
            rightDiagWin.SetActive(true);
        }
        else if(spots["2"] == 1 && spots["4"] == 1 && spots["6"] == 1){
            menuText.text = "Player 1 Wins!!!";
            menu.SetActive(true);
            winner = true;
            leftDiagWin.SetActive(true);
        }
            


    //PLAYER 2 WINS
        if(spots["0"] == 2 && spots["1"] == 2 && spots["2"] == 2){
            menuText.text = "Player 2 Wins!!!";
            menu.SetActive(true);
            winner = true;
            topRowWin.SetActive(true);
        }
        else if(spots["3"] == 2 && spots["4"] == 2 && spots["5"] == 2){
            menuText.text = "Player 2 Wins!!!";
            menu.SetActive(true);
            winner = true;
            midRowWin.SetActive(true);
        }
        else if(spots["6"] == 2 && spots["7"] == 2 && spots["8"] == 2){
            menuText.text = "Player 2 Wins!!!";
            menu.SetActive(true);
            winner = true;
            botRowWin.SetActive(true);
        }
        else if(spots["0"] == 2 && spots["3"] == 2 && spots["6"] == 2){
            menuText.text = "Player 2 Wins!!!";
            menu.SetActive(true);
            winner = true;
            leftColWin.SetActive(true);
        }
        else if(spots["1"] == 2 && spots["4"] == 2 && spots["7"] == 2){
            menuText.text = "Player 2 Wins!!!";
            menu.SetActive(true);
            winner = true;
            midColWin.SetActive(true);
        }
        else if(spots["2"] == 2 && spots["5"] == 2 && spots["8"] == 2){
            menuText.text = "Player 2 Wins!!!";
            menu.SetActive(true);
            winner = true;
            rightColWin.SetActive(true);
        }
        else if(spots["0"] == 2 && spots["4"] == 2 && spots["8"] == 2){
            menuText.text = "Player 2 Wins!!!";
            menu.SetActive(true);
            winner = true;
            rightDiagWin.SetActive(true);
        }
        else if(spots["2"] == 2 && spots["4"] == 2 && spots["6"] == 2){
            menuText.text = "Player 2 Wins!!!";
            menu.SetActive(true);
            winner = true;
            leftDiagWin.SetActive(true);
        }

        if(CheckDictionary(spots) && winner == false){
            menuText.text = "Cat Game...";
            menu.SetActive(true);
            winner = true;
        }
    }

    public bool CheckDictionary(Dictionary<string, int> dictToCheck){
        var test = dictToCheck.Where(x => x.Value != 0);
        if(test.Count() == 9){
            return true;
        }
        else{
            return false;
        }
    }



    public IEnumerator FadeTextToFullAlpha(float t, TextMeshProUGUI i){
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        i.text = turn;
        while(i.color.a < 1.0f){
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator FadeTextToZeroAlpha(float t, TextMeshProUGUI i){
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        i.text = turn;
        while(i.color.a > 0.0f){
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }

}

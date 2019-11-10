using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject playerPrefab;
    public GameObject gameHud;
    public GameObject gameMenu;

    public GameObject gameSign;
    public GameObject gameSign2;
    public GameObject gameSign3;

    public GameObject gameBox1;
    public GameObject gameBox2;
    public GameObject gameBox3;


    public GameObject playerPlaceholder;

    private GameObject currentPlayer;

    public Text playerLifesText;

    private int lifes = 3;
    private int level = 1;
    private int boxes = 0;



    // Start is called before the first frame update
    void Start() {

        string name = SceneManager.GetActiveScene().name;
        if (name == "Level02" || name == "Level03"){
            gameHud.SetActive(true);
            gameMenu.SetActive(false);
            currentPlayer = Instantiate(playerPrefab, playerPlaceholder.transform.position, Quaternion.identity);
            gameSign2.SetActive(false);
            gameSign3.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void NextLevel(){
        
        string name = SceneManager.GetActiveScene().name;
        if (name == "Level01"){  
            //Destroy(currentPlayer);
            // currentPlayer = Instantiate(playerPrefab, playerPlaceholder.transform.position, Quaternion.identity);
            SceneManager.LoadScene("Level02");
        }   
    }

    public void NextLevel2(){
        
        string name = SceneManager.GetActiveScene().name;
        if (name == "Level02"){
            //Destroy(currentPlayer);
            SceneManager.LoadScene("Level03");
        }
    }

    public void NextLevel3(){
        
        string name = SceneManager.GetActiveScene().name;
        if (name == "Level03"){
            Destroy(currentPlayer);
            gameMenu.SetActive(true);
            gameHud.SetActive(false);
        }
        
    }


    public void OpenBox(int value){
        boxes += value;
        
        if (boxes == 3){
            gameSign.SetActive(true);
            gameSign2.SetActive(true);
            gameSign3.SetActive(true);

        }
    }
    public void HideBox(string texto) {
        if (texto == "Box1"){
            gameBox1.SetActive(false);
        }
       if (texto == "Box2"){
            gameBox2.SetActive(false);
        }
        if (texto == "Box3"){
            gameBox3.SetActive(false);
        }
    }



    public void AddLife(int value) {
        lifes += value;
        playerLifesText.text = "Vidas: " + lifes;

        if (lifes == 0) {
            SceneManager.LoadScene("Level01");
        } else {
            Destroy(currentPlayer);
            currentPlayer = Instantiate(playerPrefab, playerPlaceholder.transform.position, Quaternion.identity);
        }
    }

    public void NewGame() {
        string name = SceneManager.GetActiveScene().name;
        
        if (name == "Level02" || name == "Level03" || name == "Level04"){
            SceneManager.LoadScene("Level01");
        }

        gameMenu.SetActive(false);
        gameSign.SetActive(false);
        gameHud.SetActive(true);
        currentPlayer = Instantiate(playerPrefab, playerPlaceholder.transform.position, Quaternion.identity);
    }

    public void QuitGame() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}

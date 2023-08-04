using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class EnterTheBoss : MonoBehaviour
{
    //potreban za da bi napravio uslov za pojavljivanje buttona
    [SerializeField] private NewPlanetTransition newPl;
    //button koji se poziva kada smo dosli do zadnje planete
    [SerializeField] private GameObject button;
    //pojavljivanje buttona koji prebacuje na drugu scenu
    [SerializeField] private GameObject transferSceneButton;
    private bool triggered = false;
    //bool niz za cuvanje izabranih shipova
    private const int numberOfShips = 15;
    [SerializeField] private bool[] clickedOnce = new bool[numberOfShips];
    //skirvanje shipova i buttona za ostale shopove
    [SerializeField] private GameObject hideShips;
    [SerializeField] private GameObject otherButton1;
    [SerializeField] private GameObject otherButton2;

    //za animaciju panela
    private Animator panelAnimator;
    private string currentState;
    [SerializeField] private AnimationClip panelClosingAnim;
    [SerializeField] private TestShop ships;

    //objekti korsiceni za menjanje boje
    [SerializeField] private Button[] buttons;
    [SerializeField] private GameObject[] borders;

    //za cuvanje podataka pre ulaska u drugu scenu
    [SerializeField] private DataPresistanceManager data;

    public bool[] ClickedOnce
    {
        get { return clickedOnce; }
    }

    // Start is called before the first frame update
    void Start()
    {
        panelAnimator = GetComponent<Animator>();
    }
    void ChangeAnimationState(string newState)
    {
        //stop the same aimation from interupting itself
        if (currentState == newState) return;

        //play the animation
        panelAnimator.Play(newState);
    }

    void Update()
    {
        //postavlja dugme posle svakih 5 planeta
        if (newPl.BossPlanet() == true && triggered ==false)
           {
            Debug.Log("postavio sam dugme");
            button.SetActive(true);
            triggered = true;
           }
        //proverava da li je igrac selektovao samo 3 shipa
        //dodati da mora da ima taj ship
        int numberOfSelected = 0;
        for(int i = 0; i < 16; i++)
        {
            if (clickedOnce[i] == true)
                numberOfSelected++;
        }
        if (numberOfSelected == 3)
        {
            transferSceneButton.SetActive(true);
        }
        else transferSceneButton.SetActive(false);
    }

    //otvara panel koji se pojavio
    public void OpenPanel()
    {
        ChangeAnimationState("panelPoping up");
        button.SetActive(false);
        hideShips.SetActive(false);
        otherButton1.SetActive(false);
        otherButton2.SetActive(false);
        FindObjectOfType<AudioMangaer>().Play("buttonclick");
    }

    //zatvara panel koji se pojavio
    public void ClosePanel()
    {
        ChangeAnimationState("closePanel");
        StartCoroutine(WaitToClose());
        FindObjectOfType<AudioMangaer>().Play("buttonclick");
    }
    //gasi dugme dok se ne zavrsi animacija odlaska panela
    public IEnumerator WaitToClose()
    {
        yield return new WaitForSeconds(panelClosingAnim.length);
        hideShips.SetActive(true);
        otherButton1.SetActive(true);
        otherButton2.SetActive(true);
        triggered = false;
    }
    //checkira shipove koje je aktivirao
    public void SelectedShip(int index)
    {
        if (!clickedOnce[index])
        {
            clickedOnce[index] = true;
            borders[index].SetActive(true);
            FindObjectOfType<AudioMangaer>().Play("checkIcon");
        }
        else
        {
            clickedOnce[index] = false;
            borders[index].SetActive(false);
            FindObjectOfType<AudioMangaer>().Play("uncheckIcon");
        }
    }

    public void newScene(string sceneName)
    {
        FindObjectOfType<AudioMangaer>().Play("newScene");
        data.SaveGame();
        SceneManager.LoadScene(sceneName);       
    }
}

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
    
    //za animaciju panela
    private Animator panelAnimator;
    private string currentState;
    [SerializeField] private AnimationClip panelClosingAnim;
    [SerializeField] private TestShop ships;

    //objekti korsiceni za menjanje boje
    [SerializeField] private Button[] buttons;
    [SerializeField] Color wantedColor;
    [SerializeField] Color oldColor;

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
        for(int i = 0; i < numberOfShips; i++)
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
    }

    //zatvara panel koji se pojavio
    public void ClosePanel()
    {
        ChangeAnimationState("closePanel");
        StartCoroutine(WaitToClose());
    }
    //gasi dugme dok se ne zavrsi animacija odlaska panela
    public IEnumerator WaitToClose()
    {
        yield return new WaitForSeconds(panelClosingAnim.length);
        triggered = false;
    }
    //checkira shipove koje je aktivirao
    public void SelectedShip(int index)
    {
        if (!clickedOnce[index])
        {
            clickedOnce[index] = true;
            //pokusaj menjanja boje kada je dugme pritisnuto
            ColorBlock cb = buttons[index].colors;
            cb.normalColor = wantedColor;
            cb.highlightedColor = wantedColor;
            cb.pressedColor = wantedColor;
            buttons[index].colors = cb;
        }
        else
        {
            clickedOnce[index] = false;
            //pokusaj menjanja boje kada je dugme pritisnuto
            ColorBlock cb = buttons[index].colors;
            cb.normalColor = oldColor;
            cb.highlightedColor = oldColor;
            cb.pressedColor = oldColor;
            buttons[index].colors = cb;
        }
    }

    public void newScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);       
    }
}

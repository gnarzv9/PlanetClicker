using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnterTheBoss : MonoBehaviour
{
    [SerializeField] private NewPlanetTransition newPl;
    [SerializeField] private GameObject button;
    private bool triggered = false;
    private Animator animator;
    private string currentState;
    [SerializeField] private AnimationClip panelClosingAnim;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void ChangeAnimationState(string newState)
    {
        //stop the same aimation from interupting itself
        if (currentState == newState) return;

        //play the animation
        animator.Play(newState);
    }

    void Update()
    {
        if (newPl.BossPlanet() == true && triggered ==false)
           {
            Debug.Log("postavio sam dugme");
            button.SetActive(true);
            triggered = true;
           }    
    }

    public void OpenPanel()
    {
        ChangeAnimationState("panelPoping up");
        button.SetActive(false);
    }


    public void ClosePanel()
    {
        ChangeAnimationState("closePanel");
        StartCoroutine(WaitToClose());
    }

    public IEnumerator WaitToClose()
    {
        yield return new WaitForSeconds(panelClosingAnim.length);
        triggered = false;
    }


}

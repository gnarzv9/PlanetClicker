using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum planets { planet0, planet1, planet2, planet3, planet4 , planet5 }
public class NewPlanetTransition : MonoBehaviour
{
    enum planetsName { nothing, Earth, Moon, Sun }

    [SerializeField] private HealthBarReachersZero Hp;
    private Animator animator;
    [SerializeField] private TMP_Text planetName;
    private string currentState;
    private int planetNum = 1;

    public int PlanetNum 
    {
        get { return planetNum; }
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        planetsName planetname = (planetsName)planetNum;
        planetName.text = planetname.ToString();
    }

    void ChangeAnimationState(string newState)
    {
        //stop the same aimation from interupting itself
        if (currentState == newState) return;

        //play the animation
        animator.Play(newState);
    }


    // Update is called once per frame
    void Update()
    {
        if (Hp.ChangedHp == true)
            {
                planetNum++;
                planetsName planetname = (planetsName)planetNum; //uzimaju broj na kom se nalazi enum uz pomoc planetNum promenjive
                planets numPlanet = (planets)planetNum;
                planetName.text = planetname.ToString();
                ChangeAnimationState(numPlanet.ToString());
                Debug.Log("Promenio je planetu");    
            }
    }
}

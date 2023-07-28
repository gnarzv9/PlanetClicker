using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlanetIcontransition : MonoBehaviour
{
    [SerializeField] private HealthBarReachersZero Hp;
    [SerializeField] NewPlanetTransition newPlanet;
    private Animator animatorIcon;
    private string currentState;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        animatorIcon = GetComponent<Animator>();
        yield return new WaitForEndOfFrame();
        //kada nadje broj enum sa imenom animacije menja ga
        planets numPlanet = (planets)newPlanet.PlanetNum;
        ChangeAnimationState(numPlanet.ToString());
        Debug.Log("Sacuvan je na planeti broj: " + newPlanet.PlanetNum);
        yield return null;
    }

    void ChangeAnimationState(string newState)
    {
        //stop the same aimation from interupting itself
        if (currentState == newState) return;

        //play the animation
        animatorIcon.Play(newState);
    }


    // Update is called once per frame
   void Update()
    {
        if (Hp.ChangedHp == true)
        {
            //kada nadje broj enum sa imenom animacije menja ga
            planets numPlanet = (planets)newPlanet.PlanetNum;  
            ChangeAnimationState(numPlanet.ToString()); 
        }
    }
 
}


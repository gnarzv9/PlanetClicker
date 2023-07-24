using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlanetTransition : MonoBehaviour
{
    [SerializeField] private HealthBarReachersZero Hp;
    [SerializeField] private Animator changePlanet;
    [SerializeField] private Animator changePlanetIcon;
    private bool hasTriggeredAnimation = false;
    private int planetNum = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if (Hp.ChangedHp == true)
            {
            //planet name change in here
            changePlanet.SetBool("nextPlanet", true);
            //changePlanet.CrossFade("planet3", 0f);
            changePlanetIcon.SetTrigger("planet2Tr");
                Debug.Log("Promenio je planetu");    
            }
            else changePlanet.SetBool("nextPlanet", false);
    }
    public void ResetAnimationTrigger()
    {
        hasTriggeredAnimation = false;
    }
}

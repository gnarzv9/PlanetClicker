using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum planets { planet0, planet1, planet2, planet3, planet4 , planet5 } // napraviti poseban enum za boseve
public class NewPlanetTransition : MonoBehaviour //, IDataPresistance
{
    enum planetsName { nothing, Earth, Moon, Sun ,WettyPatty,IceSpice, boss} //zameniti ovo sa nizom stringova

    [SerializeField] private HealthBarReachersZero Hp;
    private Animator animator;
    [SerializeField] private TMP_Text planetName;
    private string currentState;
    private int planetNum = 1;
    [SerializeField] private bool killedBoss = false;
    [SerializeField] private AnimationClip explosion;
    public int PlanetNum 
    {
        get { return planetNum; }
    }

    //public void LoadData(GameData data)
    //{
    //    this.planetNum = data.planetNum;
    //}

    //public void SaveData(ref GameData data)
    //{
    //    data.planetNum = this.planetNum;
    //}

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
        animator.Play(newState,0,0f);
    }

    //public void Awake()
    //{
    //    ////menja planetu pri ulasku u igricu
    //    planets numPlanet = (planets)planetNum;
    //    ChangeAnimationState(numPlanet.ToString());
    //    planetsName planetname = (planetsName)planetNum;
    //    planetName.text = planetname.ToString();
    //}


    // Update is called once per frame
    void Update()
    {
        if (Hp.ChangedHp == true)   //menjanje planete na smrti
            {
                planetNum++;
                //menjanje imena planete
                planetsName planetname = (planetsName)planetNum;              
                if (planetname.ToString() == "boss") // nasao je enum sa imenom boss u sebi
                    {
                        if(killedBoss == false)
                            {
                                planetNum--;
                                Debug.Log("Nije ubio bosa vraca se na zadnju planetu");
                            }
                        else
                            {
                                planetNum++;
                                Debug.Log("Ubio je bosa ide u drugi univerzum");
                             }
                    }

                //menja ime planete
                planetname = (planetsName)planetNum;
                planetName.text = planetname.ToString();


            //explodira planeta i menja planetu
            StartCoroutine(Explosion(planetname));
        }
    }
    //posle svake pete planete ne menja helte
    public bool BossPlanet()
    {
        if (planetNum % 5 == 0)
            return true;
        return false;
    }

    private IEnumerator Explosion(planetsName planetname)
    {
        ChangeAnimationState("planetExplosion");       
        yield return new WaitForSeconds(explosion.length);
        planets numPlanet = (planets)planetNum;
        ChangeAnimationState(numPlanet.ToString());
        planetName.text = planetname.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LemonPoint
{
    public int tree;
    public int spot;
    public int lemonloc;

    public LemonPoint(int t, int s, int l)
    {
        tree = t;
        spot = s;
        lemonloc = l;
    }
}

public class OrchardController : MonoBehaviour {
    /*
    public TreeController[] Orchard;
    public float growthrate;


    private int randTree;
    private int randLemon;
    private float nextGrow;

    public Text scoreView;
    public Text horseScoreView;
    public Text horseScoreSub;
    public Text scoreAdd;


    private int score = 0;
    private int horseScore = 0;

    // Struct for holding tree and spot
    
    // Queue for horses to be able to go after lemons
    public Queue<LemonPoint> lemonQueue = new Queue<LemonPoint>();

    void Start()
    {
        scoreView.text = "Your score: 0 Lemons";
        horseScoreView.text = "Horse score: 0 Lemons";

        nextGrow = Time.time + growthrate;
    }

    void Update()
    {
        if (Time.time > nextGrow)
        {
            nextGrow = Time.time + growthrate;
            Grower();
        }
    }

    void Grower()
    {
        randTree = Random.Range(0, 16);
        randLemon = Random.Range(0, 4);

        lemonQueue.Enqueue(new LemonPoint( randTree, randLemon , -1));

        Orchard[randTree].grow(randLemon);
    }

    public bool curObjEaten(LemonPoint loc)
    {
        if(loc == null)
        {
            return false;
        }
        if(loc.lemonloc == -1)
        {
            return false;
        }
        return !Orchard[loc.tree].isGrown[loc.spot];
    }

    public bool hasNextLemon()
    {
        if(lemonQueue.Count == 0)
        {
            return false;
        }
        return true;
    }

    public LemonPoint nextLemon()
    {
        if(lemonQueue.Count != 0)
        {
            LemonPoint p = lemonQueue.Dequeue();
            while(!Orchard[p.tree].isGrown[p.spot])
            {
                if(lemonQueue.Count == 0)
                {
                    return null;
                }

                p = lemonQueue.Dequeue();
            }

            int[] coords = Orchard[p.tree].getCoord(p.spot);
            p.lemonloc = coords[0] + coords[1] * 9;
            return p;
            
        }
        else
        {
            return null;
        }
    }

    public void scorer()
    {
        string ess;
        score++;
        if (score == 1)
            ess = "";
        else
            ess = "s";
        scoreView.text = "Your score: " + score + " Lemon"+ ess;
    }

    public void horseScorer()
    {
        string ess;
        horseScore++;
        if (horseScore == 1)
            ess = "";
        else
            ess = "s";

        horseScoreView.text = "Horse score: " + horseScore + " Lemon" + ess;
    }

    public void stolen(int steal)
    {
        string hess, ess;

        horseScore -= steal;
        score += steal;

        if (score == 1)
            ess = "";
        else
            ess = "s";
        scoreView.text = "Your score: " + score + " Lemon" + ess;
        scoreAdd.text = "+" + steal;
        scoreAdd.GetComponent<resetByTime>().resetStart();


        if (horseScore == 1)
            hess = "";
        else
            hess = "s";

        horseScoreView.text = "Horse score: " + horseScore + " Lemon" + hess;
        horseScoreSub.text = "-" + steal;
        horseScoreSub.GetComponent<resetByTime>().resetStart();


    }*/
}

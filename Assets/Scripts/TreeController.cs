using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour {

    public GameObject[] Lemons;
    public Waypoint loc;
    public GameObject allWaypoints;
    public bool[] isGrown;
    private int lemonCount = 0;
    public float growTime;
    public float decayTime;
    public GameObject godRayz;
    public OrchardController Orchard;

    private int[,] growthSpot = new int[4, 2];

    private Transform tempWP;

    public void grow(int spot)
    {
        if (!isGrown[spot])
        {
            int tempX = 0;
            int tempZ = 0;

            StartCoroutine(LerpGrow(spot, new Vector3(0, 0, 0), new Vector3(0.75f, 0.75f, 0.75f)));
            isGrown[spot] = true;
            lemonCount++;

            switch (spot)
            {
                case 0:
                    tempX = loc.X - 1;
                    tempZ = loc.Z;
                    break;
                case 1:
                    tempX = loc.X;
                    tempZ = loc.Z - 1;
                    break;
                case 2:
                    tempX = loc.X + 1;
                    tempZ = loc.Z;
                    break;
                case 3:
                    tempX = loc.X;
                    tempZ = loc.Z + 1;
                    break;
            }
            tempWP = allWaypoints.transform.Find("Row " + tempZ + "/Waypoint " + tempX);
            growthSpot[spot, 0] = tempX;
            growthSpot[spot, 1] = tempZ;


            GameObject rayz = Instantiate(godRayz, tempWP);
            rayz.transform.position = new Vector3(tempWP.position.x, (tempWP.position.y - 0.9f), tempWP.position.z);
            rayz.GetComponent<GetLemon>().addTree(this, spot);
        }
    }

    public void pick(int spot)
    {
        if (isGrown[spot])
        {
            isGrown[spot] = false;
            lemonCount--;
            StartCoroutine(LerpDecay(spot, new Vector3(0.75f, 0.75f, 0.75f), new Vector3(0, 0, 0)));
            Orchard.scorer();
        }
    }

    public void eat(int spot)
    {
        if (isGrown[spot])
        {
            isGrown[spot] = false;
            lemonCount--;
            StartCoroutine(LerpDecay(spot, new Vector3(0.75f, 0.75f, 0.75f), new Vector3(0, 0, 0)));
            Orchard.horseScorer();
        }
    }

    public int[] getCoord(int spot)
    {
        int[] temp = new int[2] {growthSpot[spot, 0], growthSpot[spot, 1]};

        return temp;
    }

    IEnumerator LerpGrow(int spot, Vector3 Start, Vector3 End)
    {
        float progress = 0;

        while (progress <= 1)
        {
            Lemons[spot].transform.localScale = Vector3.Lerp(Start, End, progress);
            progress += Time.deltaTime * growTime;
            yield return null;
        }
        Lemons[spot].transform.localScale = End;
    }

    IEnumerator LerpDecay(int spot, Vector3 Start, Vector3 End)
    {
        float progress = 0;

        while (progress <= 1)
        {
            Lemons[spot].transform.localScale = Vector3.Lerp(Start, End, progress);
            progress += Time.deltaTime * decayTime;
            yield return null;
        }
        Lemons[spot].transform.localScale = End;
    }
}

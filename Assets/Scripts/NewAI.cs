using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint
{
    public bool Traversable;
    public bool LemonCheck;
    public int X;
    public int Z;

    // Needed for aStar
    public int h;
    public int g;
    public int f;

    public int length;
    public bool wall;
    public List<Waypoint> neighbors;
    public Waypoint previous;
    public GameObject vway;

    public Waypoint(int l, int nx, int nz, GameObject vwaypoint)
    {
        this.length = l;
        this.X = nx;
        this.Z = nz;
        this.Traversable = true;
        this.LemonCheck = false;
        this.wall = false;
        this.neighbors = new List<Waypoint>();
        this.previous = null;
        vwaypoint.transform.position = new Vector3(this.X, 1, this.Z);
        if(Random.Range(0, 1.0f) < .4)
        {
            vwaypoint.transform.localScale = new Vector3(.1f, .1f, .1f);
            this.wall = true;
        }
        this.vway = vwaypoint;


    }

    public Waypoint(Waypoint w)
    {
        this.X = w.X;
        this.Z = w.Z;
    }
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override bool Equals(object other)
    {
        if (other == null) return false;
        Waypoint way = other as Waypoint;
        if (this.X == way.X && this.Z == way.Z)
        {
            return true;
        }
        return false;
    }

    public void printNeighbors()
    {
        for (int i = 0; i < neighbors.Count; i++)
        {
            //print("Location " + (i + 1) + " has coords x:" + neighbors[i].X + " y:" + neighbors[i].Z);
        }
    }
    
}

public class NewAI : MonoBehaviour {
    

    public int xSize;
    public int zSize;

    public GameObject guiwaypoint;

    private Waypoint[,] waypoints;

    public int distance;
    public LineRenderer lr;

    public struct Location
    {
        public int x;
        public int z;
        public Location(int x, int z)
        {
            this.x = x;
            this.z = z;
        }
    }

    // Use this for initialization
    void Start () {
        // Declare the array
        waypoints = new Waypoint[xSize, zSize];
        generateWayPoints(xSize, zSize);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp("space"))
        {
            Debug.Log("starting...");
            aStar(waypoints[0, 0], waypoints[xSize - 1, zSize - 1]);
        }
        if(Input.GetKeyUp("r"))
        {
            for (int i = 0; i < xSize; i++)
            {
                for (int j = 0; j < zSize; j++)
                {
                    Destroy(waypoints[i,j].vway);
                }
            }
            generateWayPoints(xSize, zSize);
        }
	}

    void generateWayPoints(int x, int z)
    {

        for(int i = 0; i < x; i++)
        {
            for(int j = 0; j < z; j++)
            {
                waypoints[i, j] = new Waypoint(xSize, j * distance, i * distance, Instantiate(guiwaypoint) as GameObject);
                // Add the neighbors
                
            }
        }
        waypoints[0, 0].wall = false;
        waypoints[xSize - 1, zSize - 1].wall = false;
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < z; j++)
            {
                
                // Add the neighbors
                if (i < x - 1)
                {
                    waypoints[i, j].neighbors.Add(waypoints[i + 1, j]);
                }
                if (i > 0)
                {
                    waypoints[i, j].neighbors.Add(waypoints[i - 1, j]);
                }
                if (j < z - 1)
                {
                    waypoints[i, j].neighbors.Add(waypoints[i, j + 1]);
                }
                if (j > 0)
                {
                    waypoints[i, j].neighbors.Add(waypoints[i, j - 1]);
                }
                if (i > 0 && j > 0)
                {
                    waypoints[i, j].neighbors.Add(waypoints[i - 1, j - 1]);
                }
                if (i < x - 1 && j > 0)
                {
                    waypoints[i, j].neighbors.Add(waypoints[i + 1, j - 1]);
                }
                if (i > 0 && j < z - 1)
                {
                    waypoints[i, j].neighbors.Add(waypoints[i - 1, j + 1]);
                }
                if (i < x - 1 && j < z - 1)
                {
                    waypoints[i, j].neighbors.Add(waypoints[i + 1, j + 1]);
                }
            }
        }
        
        
    }

    void drawPath(Stack<Waypoint> ways)
    {
        lr.numPositions = ways.Count;
        int i = 0;
        while(ways.Count > 0)
        { 
            Waypoint temp = ways.Pop();

            lr.SetPosition(i, new Vector3(temp.X, 1, temp.Z));
            i++;
        }
    }


    // heuristic calculation
    private int heuristic(Waypoint from, Waypoint end)
    {
        return Mathf.Abs(from.X - end.X) + Mathf.Abs(from.Z - end.Z);
    }

    private void aStar(Waypoint start, Waypoint end)
    {
        List<Stack<Waypoint>> asdfasdf = new List<Stack<Waypoint>>();

        if (start.Equals(end))
        {
            return;
        }
        
        List<Waypoint> openSet = new List<Waypoint>();
        List<Waypoint> closedSet = new List<Waypoint>();
        openSet.Add(start);

        Waypoint curr;

        while (openSet.Count > 0)
        {

            int bestOption = 0;

            for(int i = 0; i < openSet.Count; i++)
            {
                if(openSet[i].f < openSet[bestOption].f)
                {
                    bestOption = i;
                }
            }

            curr = openSet[bestOption];

            if(curr.Equals(end))
            {
                Stack<Waypoint> pathy = new Stack<Waypoint>();
                Waypoint tempy = curr;
                pathy.Push(tempy);
                while (tempy.previous != null)
                {
                    pathy.Push(tempy.previous);
                    tempy = tempy.previous;
                }
                asdfasdf.Add(pathy);
                print("starting coroutine...");
                StartCoroutine(Wait(asdfasdf));
                return;
            }
            
            openSet.Remove(curr);

            closedSet.Add(curr);

            List<Waypoint> neighbors = curr.neighbors;
            
            for(int i = 0; i < neighbors.Count; i++)
            {
                Waypoint neighbor = neighbors[i];

                if(!closedSet.Contains(neighbor) && !neighbor.wall)
                {
                    
                    int tentativeG = curr.g + heuristic(neighbor, curr);

                    bool newBestPath = false;
                    if(openSet.Contains(neighbor))
                    {
                        if(tentativeG < neighbor.g)
                        {
                            neighbor.g = tentativeG;
                            newBestPath = true;
                        }
                    }
                    else
                    {
                        neighbor.g = tentativeG;
                        newBestPath = true;
                        openSet.Add(neighbor);
                    }

                    if(newBestPath)
                    {
                        neighbor.h = heuristic(neighbor, end);
                        neighbor.f = neighbor.g + neighbor.h;
                        neighbor.previous = curr;

                    }
                }
            }
            
            // Draw current path
            
            Stack<Waypoint> path = new Stack<Waypoint>();
            Waypoint temp = curr;
            path.Push(temp);
            while (temp.previous != null)
            {
                path.Push(temp.previous);
                temp = temp.previous;
            }
            asdfasdf.Add(path);
            
        }
        print("starting coroutine...");
        StartCoroutine(Wait(asdfasdf));
    }

    IEnumerator Wait(List<Stack<Waypoint>> asdf)
    {
        for (int i = 0; i < asdf.Count; i++)
        {
            lr.numPositions = 0;
            drawPath(asdf[i]);
            yield return new WaitForSeconds(.02f);
        }
    }
}

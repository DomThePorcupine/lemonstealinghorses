using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetLemon : MonoBehaviour {

    private TreeController trees;
    private int sides;
    private int lemonCount = 0;

    public void addTree(TreeController tree, int side)
    {
        trees = tree;
        sides = side;
        lemonCount++;
    }

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            trees.pick(sides);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else if(other.tag == "Horse")
        {
            trees.eat(sides);
            other.GetComponent<AI>().destroy();
            other.GetComponent<HeldLemons>().lemons++;
            gameObject.SetActive(false);
            Destroy(gameObject);
            
        }

    }
}

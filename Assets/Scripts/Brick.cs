using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);  //Disable the brick
    }
}

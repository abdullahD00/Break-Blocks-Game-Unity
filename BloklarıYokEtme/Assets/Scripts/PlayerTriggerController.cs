using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    [SerializeField] GameObject Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player.GetComponent<PlayerController>().OnGround = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player.GetComponent<PlayerController>().OnGround = false;
    }

}

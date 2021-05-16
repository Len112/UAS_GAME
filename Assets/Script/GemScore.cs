using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScore : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ScoreSystem.sScoresystem.IncreaseScore(5);
            Destroy(this.gameObject);
        }
    }
}

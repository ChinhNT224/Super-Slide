using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private static int touchedGoalCount = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            touchedGoalCount++;

            Debug.Log("Player va chạm vào: " + gameObject.name);

            if (touchedGoalCount == 4)
            {
                AudioManager.instance.PlayWinSound();
                Debug.Log("You Win!");
                PlayerManager.gameWin = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            touchedGoalCount--;
        }
    }
}

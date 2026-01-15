using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControlledObject : MonoBehaviour
{
    [SerializeField] private SplineController splineController;
    [SerializeField] private ScoringController scoringController;
    private List<GameObject> passedGameObject = new List<GameObject>();

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Goal"))
        {
            scoringController.Goal();
        }

        if (other.CompareTag("Reward"))
        {
            if (passedGameObject.Contains(other.gameObject)) return;

            scoringController.Reward();
            other.gameObject.SetActive(false);
            passedGameObject.Add(other.gameObject);
            return;
        }

        if (other.CompareTag("Bad Reward"))
        {
            scoringController.MehReward();
            other.gameObject.transform.parent.gameObject.SetActive(false);
            return;
        }


        if (other.CompareTag("Obstacle"))
        {
            splineController.Reverse();
            scoringController.Warn();
        }

    }

    [ContextMenu("Reset Game")]
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    [ContextMenu("Next Level")]
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }

}

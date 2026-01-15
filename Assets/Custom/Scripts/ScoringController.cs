using MoreMountains.Feedbacks;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Splines;

public class ScoringController : MonoBehaviour
{
    [SerializeField] private MMF_Player goalFeedback;
    [SerializeField] private MMF_Player rewardFeedback;
    [SerializeField] private MMF_Player mehFeedback;
    [SerializeField] private MMF_Player warningFeedback;
    [SerializeField] private SplineContainer container;
    [SerializeField] private MMF_Player perfectCounter;
    [SerializeField] private MMF_Player mehCounter;
    [SerializeField] private MMF_Player warningCounter;

    [SerializeField] private TextMeshProUGUI maxScoreUI;
    [SerializeField] private TextMeshProUGUI currentScoreUI;

    private int currentScore = 0;
    [SerializeField] private int maxScore;

    private int mehCount = 0;
    private int warningCount = 0;

    private void OnEnable()
    {
        // If there is already value assigned, skip automatic assignment.
        if (maxScore == 0)
        {
            foreach (Spline spline in container.Splines)
            {
                maxScore += spline.Knots.Count();
            }
        }
        
        maxScoreUI.text = maxScore.ToString();
    }

    [ContextMenu("Goal")]
    public void Goal()
    {
        perfectCounter.GetFeedbackOfType<MMF_TMPCountTo>().CountTo = currentScore;
        warningCounter.GetFeedbackOfType<MMF_TMPCountTo>().CountTo = warningCount;
        mehCounter.GetFeedbackOfType<MMF_TMPCountTo>().CountTo = mehCount;

        goalFeedback.PlayFeedbacks();
    }

    public void Reward()
    {
        currentScore++;
        currentScoreUI.text = currentScore.ToString();
        rewardFeedback.PlayFeedbacks();
    }

    public void MehReward()
    {
        mehCount++;
        mehFeedback.PlayFeedbacks();
    }

    public void Warn()
    {
        warningCount++;
        warningFeedback.PlayFeedbacks();
    }


    public void ResetState()
    {
        currentScore = 0;
        mehCount = 0;
        warningCount = 0;
        currentScoreUI.text = currentScore.ToString();
    }
}

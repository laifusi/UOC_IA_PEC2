using System;
using UnityEngine;

public class Kid : MonoBehaviour
{
    public bool IsReadyToPlay; //bool to indicate we are ready to play
    public Transform ballPosition; //point the ball should go to
    public bool IsBallOnMe; //bool to indicate if we have the ball
    public GameObject ballPrefab; //prefab to instatiate the ball
    public Action OnChangedReady; //Action to indicate we changed the ready to play state
    public Ball ball; //Ball

    /// <summary>
    /// Set the IsReadyToPlay variable and invoke the OnChangedReady Action
    /// </summary>
    /// <param name="ready">whether we are ready or not</param>
    public void SetIsReadyToPlay(bool ready)
    {
        IsReadyToPlay = ready;
        OnChangedReady?.Invoke();
    }

    /// <summary>
    /// Set the IsBallOnMe variable
    /// </summary>
    /// <param name="onMe">whether the ball is or isn't on the Kid</param>
    public void SetBallOnMe(bool onMe)
    {
        IsBallOnMe = onMe;
    }
}

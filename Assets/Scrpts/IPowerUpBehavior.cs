using UnityEngine;

public interface IPowerUpBehavior
{
    void Activate();
    void Update();
    bool IsFinished();
}


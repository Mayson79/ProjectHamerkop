namespace PH.MessengerSystem.MessageTargets
{
    public interface IRaycastHitTarget : IMessageTarget
    {
        void OnRaycastHitNothing();
        void OnRaycastHitObstacle(string name, float distance);
    }
}
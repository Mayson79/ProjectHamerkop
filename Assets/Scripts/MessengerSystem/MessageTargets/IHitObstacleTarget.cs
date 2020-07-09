namespace PH.MessengerSystem.MessageTargets
{
    public interface IHitObstacleTarget : IMessageTarget
    {
        void OnHitObstacle(string name, float stoppingForce);
    }
}

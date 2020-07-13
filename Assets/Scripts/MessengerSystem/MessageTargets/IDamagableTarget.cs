namespace PH.MessengerSystem.MessageTargets
{
    public interface IDamagableTarget : IMessageTarget
    {
        void SetHealth(float health);
    }
}

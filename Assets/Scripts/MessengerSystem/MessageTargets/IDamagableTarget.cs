namespace PH.MessengerSystem.MessageTargets
{
    public interface IDamagableTarget : IMessageTarget
    {
        void currentHealth(int health);

        void setMaxHealth(int health);
    }
}

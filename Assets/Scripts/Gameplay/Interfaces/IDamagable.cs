namespace PH.Gameplay.Interfaces {
    public interface IDamagable
    {
        void Damage(object invoker, float amount);
        bool CanDamage(object invoker, float amount);
    }
}

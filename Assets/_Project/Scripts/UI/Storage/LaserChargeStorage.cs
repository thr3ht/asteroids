using System;

namespace _Project.Scripts.UI.Storage
{
    public sealed class LaserChargeStorage
    {
        public event Action<int> OnChargeChanged;

        public int Charge { get; private set; }

        public void SetCharge(int charge)
        {
            Charge = charge;
            OnChargeChanged?.Invoke(charge);
        }
    }
}
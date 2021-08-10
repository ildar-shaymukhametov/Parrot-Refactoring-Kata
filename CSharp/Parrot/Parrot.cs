using System;

namespace Parrot
{
    public class Parrot
    {
        public virtual double GetSpeed()
        {
            return 12.0;
        }
    }

    public class EuropeanParrot : Parrot { }

    public class AfricanParrot : Parrot
    {
        private readonly int _numberOfCoconuts;
        public AfricanParrot(int numberOfCoconuts)
        {
            _numberOfCoconuts = numberOfCoconuts;
        }

        public override double GetSpeed()
        {
            return Math.Max(0, base.GetSpeed() - GetLoadFactor() * _numberOfCoconuts);
        }

        private double GetLoadFactor()
        {
            return 9.0;
        }
    }
    
    public class NorwegianParrot : Parrot
    {
        private readonly double _voltage;
        private readonly bool _isNailed;
        public NorwegianParrot(double voltage, bool isNailed)
        {
            _voltage = voltage;
            _isNailed = isNailed;
        }

        public override double GetSpeed()
        {
            return _isNailed ? 0 : GetBaseSpeed(_voltage);
        }

        private double GetBaseSpeed(double voltage)
        {
            return Math.Min(24.0, voltage * base.GetSpeed());
        }
    }
}
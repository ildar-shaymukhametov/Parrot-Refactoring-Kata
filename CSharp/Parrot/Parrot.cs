using System;

namespace Parrot
{
    public class Parrot
    {
        private readonly bool _isNailed;
        private readonly int _numberOfCoconuts;
        private readonly ParrotTypeEnum _type;
        private readonly double _voltage;

        public Parrot(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed)
        {
            _type = type;
            _numberOfCoconuts = numberOfCoconuts;
            _voltage = voltage;
            _isNailed = isNailed;
        }

        public virtual double GetSpeed()
        {
            return 12.0;
        }

        private double GetBaseSpeed(double voltage)
        {
            return Math.Min(24.0, voltage * GetSpeed());
        }

        private double GetLoadFactor()
        {
            return 9.0;
        }
    }

    public class EuropeanParrot : Parrot
    {
        public EuropeanParrot() : base(default, default, default, default) { }
    }

    public class AfricanParrot : Parrot
    {
        private readonly int _numberOfCoconuts;
        public AfricanParrot(int numberOfCoconuts) : base(default, default, default, default)
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
        public NorwegianParrot(double voltage, bool isNailed) : base(default, default, default, default)
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
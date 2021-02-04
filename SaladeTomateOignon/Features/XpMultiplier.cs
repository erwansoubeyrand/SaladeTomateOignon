using System;
using BlueRain;

namespace SaladeTomateOignon.Features
{
    internal class XpMultiplier
    {
        private readonly IntPtr _baseAddress;
        private readonly NativeMemory _memory;

        public XpMultiplier(IntPtr baseAddress, NativeMemory memory)
        {
            _baseAddress = baseAddress;
            _memory = memory;
        }

        public void PlayerXpMultiplier(float multiplier)
        {
            _memory.Write(_baseAddress + Offsets.ZMXPScaleBase + Offsets.ZombieXpScaleBase.XPUserReal, multiplier);
            //_memory.Write(_baseAddress+Offsets.ZMXPScaleBase+Offsets.ZombieXpScaleBase.XPUserFake, multiplier);
        }

        public void GunXpMultiplier(float multiplier)
        {
            _memory.Write(_baseAddress + Offsets.ZMXPScaleBase + Offsets.ZombieXpScaleBase.XPGun, multiplier);
        }
    }
}
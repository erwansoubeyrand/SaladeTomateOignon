using System;
using BlueRain;

namespace SaladeTomateOignon.Features
{
    internal class SpeedMultiplier
    {
        private readonly IntPtr _baseAddress;
        private readonly NativeMemory _memory;

        public SpeedMultiplier(IntPtr baseAddress, NativeMemory memory)
        {
            _baseAddress = baseAddress;
            _memory = memory;
        }

        public void SetSpeed(float speed)
        {
            _memory.Write(false, speed, _baseAddress + Offsets.PlayerBase, (IntPtr) Offsets.PlayerCompPtr.RunSpeed);
        }
    }
}
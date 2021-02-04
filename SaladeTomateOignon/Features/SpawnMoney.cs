using System;
using BlueRain;

namespace SaladeTomateOignon.Features
{
    internal class SpawnMoney
    {
        private readonly IntPtr _baseAddress;
        private readonly NativeMemory _memory;

        public SpawnMoney(IntPtr baseAddress, NativeMemory memory)
        {
            _baseAddress = baseAddress;
            _memory = memory;
        }

        public void InfiniteMoney()
        {
            _memory.Write(true, 13337, _baseAddress + Offsets.PlayerBase, (IntPtr) Offsets.PlayerCompPtr.Points);
        }
    }
}
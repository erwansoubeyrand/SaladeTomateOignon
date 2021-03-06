﻿using System;
using BlueRain;
using SaladeTomateOignon.Utils;

namespace SaladeTomateOignon.Features
{
    internal class MiscFeatures
    {
        private readonly IntPtr _baseAddress;
        private readonly NativeMemory _memory;
        private bool _critOnly;

        private bool _infraredVision;

        public MiscFeatures(IntPtr baseAddress, NativeMemory memory)
        {
            _baseAddress = baseAddress;
            _memory = memory;
        }

        public void ToggleInfraredVision()
        {
            if (!_infraredVision)
            {
                _infraredVision = !_infraredVision;
                _memory.Write<byte>(false, 0x10, _baseAddress + Offsets.PlayerBase,
                    (IntPtr) Offsets.PlayerCompPtr.InfraredVision);
            }
            else
            {
                _infraredVision = !_infraredVision;
                _memory.Write<byte>(false, 0x0, _baseAddress + Offsets.PlayerBase,
                    (IntPtr) Offsets.PlayerCompPtr.InfraredVision);
            }
        }

        public void DoRapidFire()
        {
            if (KeyUtils.GetKeyDown(0x1))
            {
                _memory.Write(false, 0, _baseAddress + Offsets.PlayerBase, (IntPtr) Offsets.PlayerCompPtr.RapidFire1);
                _memory.Write(false, 0, _baseAddress + Offsets.PlayerBase, (IntPtr) Offsets.PlayerCompPtr.RapidFire2);
            }
        }

        public void CritOnly()
        {
            if (!_critOnly)
            {
                _critOnly = !_critOnly;
                _memory.Write(false, -1, _baseAddress + Offsets.PlayerBase, (IntPtr) Offsets.PlayerCompPtr.CritOffset1);
                _memory.Write(false, -1, _baseAddress + Offsets.PlayerBase, (IntPtr) Offsets.PlayerCompPtr.CritOffset2);
                _memory.Write(false, -1, _baseAddress + Offsets.PlayerBase, (IntPtr) Offsets.PlayerCompPtr.CritOffset3);
                _memory.Write(false, -1, _baseAddress + Offsets.PlayerBase, (IntPtr) Offsets.PlayerCompPtr.CritOffset4);
                _memory.Write(false, -1, _baseAddress + Offsets.PlayerBase, (IntPtr) Offsets.PlayerCompPtr.CritOffset5);
                _memory.Write(false, -1, _baseAddress + Offsets.PlayerBase, (IntPtr) Offsets.PlayerCompPtr.CritOffset6);
            }
            else
            {
                _critOnly = !_critOnly;
            }
        }

        public void SetWeapon(int id)
        {
            _memory.Write(false, id, _baseAddress + Offsets.PlayerBase,
                (IntPtr) Offsets.PlayerCompPtr.SetWeaponID /*+ 0x40*/);
        }

        public void AutomaticWeaponSwitch()
        {
        }
    }
}
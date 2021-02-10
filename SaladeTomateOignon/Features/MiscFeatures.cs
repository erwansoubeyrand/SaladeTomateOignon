using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BlueRain;
using SaladeTomateOignon.Enums;
using SaladeTomateOignon.Utils;

namespace SaladeTomateOignon.Features
{
    internal class MiscFeatures
    {
        private readonly IntPtr _baseAddress;
        private readonly NativeMemory _memory;

        private bool _critOnly;
        private bool _automaticWeaponSwitch = true;
        private bool _infraredVision;
        
        private Queue _weaponQueue;

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
                _memory.Write(false, (Byte)255, _baseAddress + Offsets.PlayerBase, (IntPtr) Offsets.PlayerCompPtr.CritOffset);
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
            SetQueue();
            int killCount = _memory.Read<int>(false, _baseAddress + Offsets.PlayerBase, (IntPtr) Offsets.PlayerCompPtr.KillCount);
            if (killCount % 5 == 0)
            {
                SetWeapon((int)_weaponQueue.Peek());
                _weaponQueue.Dequeue();
            }
        }

        private void SetQueue()
        {
            if (_automaticWeaponSwitch)
            {
                _weaponQueue = new Queue();
                var weapons = WeaponsUtils.GetWeaponsIds<WeaponsIds>();
                foreach (var weaponId in weapons.Select(e => e.Key))
                {
                    _weaponQueue.Enqueue(weaponId);
                }
                _automaticWeaponSwitch = false;
            }
        }
    }
}
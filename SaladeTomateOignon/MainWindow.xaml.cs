using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using SaladeTomateOignon.Enums;
using SaladeTomateOignon.Utils;

namespace SaladeTomateOignon
{
    public partial class MainWindow : Window
    {
        private readonly BackgroundWorker _backgroundWorker = new BackgroundWorker();
        private WpfConsole _console;
        private Core _core;
        
        private bool _critOnly;
        private bool _automaticSwitch;
        private bool _infiniteAmmo;
        private bool _infiniteMoney;
        private bool _instantKill;
        private bool _rapidFire;
        private bool _teleportZombies;
        private bool _teleportZombiesLocation;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            _core = new Core(_console);

            if (_core.Start())
            {
                _console.WriteLine("We gucci fam.", Brushes.Green);
                WeaponIdComboBox.ItemsSource = WeaponsUtils.GetWeaponsIds<WeaponsIds>();
                EnableContentOnWindow();
                _backgroundWorker.DoWork += BackgroundWorkerDoWork;
                _backgroundWorker.RunWorkerAsync();
            }
            else
            {
                _console.WriteLine("Please start inside a match.", Brushes.Red);
            }
        }

        private void EnableContentOnWindow()
        {
            GodModeCheckBox.IsEnabled = true;
            SpeedHackCheckBox.IsEnabled = true;
            MoneyHackCheckBox.IsEnabled = true;
            InfiniteAmmoCheckBox.IsEnabled = true;
            MoneyHackCheckBox.IsEnabled = true;
            RapidFireCheckBox.IsEnabled = true;
            AlwaysCritCheckBox.IsEnabled = true;
            ThermalVisonCheckBox.IsEnabled = true;
            AutoSwitchWeaponCheckBox.IsEnabled = true;
            InstantKillCheckBox.IsEnabled = true;
            TeleportZombieCheckBox.IsEnabled = true;
            TeleportZombiePositionCheckBox.IsEnabled = true;
            SetPositionbutton.IsEnabled = true;
            XpModiferCheckBox.IsEnabled = true;
            GunXpModiferCheckBox.IsEnabled = true;
            ChangeWeaponButton.IsEnabled = true;
        }

        private void GodModeEnable(object sender, RoutedEventArgs e)
        {
            _console.WriteLine("God Mode Enabled", Brushes.Green);
            _core.GodMode.EnableGodMode();
        }

        private void GodModeDisable(object sender, RoutedEventArgs e)
        {
            _console.WriteLine("God Mode Disabled", Brushes.Green);
            _core.GodMode.DisableGodMode();
        }

        private void SpeedHackEnabled(object sender, RoutedEventArgs e)
        {
            _console.WriteLine("Speed Hack Enabled", Brushes.Green);
            _core.SpeedMultiplier.SetSpeed((float) SpeedHackValueSlider.Value);
        }

        private void SpeedHackDisable(object sender, RoutedEventArgs e)
        {
            _console.WriteLine("Speed Hack Disabled", Brushes.Green);
            _core.SpeedMultiplier.SetSpeed(1f);
        }

        private void InfiniteAmmoEnable(object sender, RoutedEventArgs e)
        {
            _console.WriteLine("Infinite Ammo Enabled", Brushes.Green);
            _infiniteAmmo = true;
        }

        private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(100);

                try
                {
                    if (_infiniteAmmo)
                        _core.InfiniteAmmo.DoInfiniteAmmo();

                    if (_infiniteMoney)
                        _core.MoneyHack.InfiniteMoney();

                    if (_instantKill)
                        _core.ZombieHack.OneHpZombies();

                    if (_teleportZombies)
                        _core.ZombieHack.TeleportZombies(true);

                    if (_rapidFire)
                        _core.MiscFeatures.DoRapidFire();

                    if (_teleportZombiesLocation)
                        _core.ZombieHack.TeleportZombies(false);

                    if (_critOnly)
                        _core.MiscFeatures.CritOnly();
                    
                    if (_automaticSwitch)
                        _core.MiscFeatures.AutomaticWeaponSwitch();
                }
                catch (Exception exception)
                {
                    _console.WriteLine(exception.Message, Brushes.Red);
                }
            }
        }

        private void InfiniteAmmoDisable(object sender, RoutedEventArgs e)
        {
            _console.WriteLine("Infinite Ammo Disabled", Brushes.Green);
            _infiniteAmmo = false;
        }

        private void InfiniteMoneyHack(object sender, RoutedEventArgs e)
        {
            _console.WriteLine("Infinite Money Enabled", Brushes.Green);
            _infiniteMoney = true;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            _console = new WpfConsole(Console);
        }

        private void InfiniteMoneyDisable(object sender, RoutedEventArgs e)
        {
            _console.WriteLine("Infinite Money Disabled", Brushes.Green);
            _infiniteMoney = false;
        }

        private void InstantKillEnable(object sender, RoutedEventArgs e)
        {
            _console.WriteLine("Instant Kill Enabled", Brushes.Green);
            _instantKill = true;
        }

        private void InstantKillDisable(object sender, RoutedEventArgs e)
        {
            _console.WriteLine("Instant Kill Disabled", Brushes.Green);
            _instantKill = false;
        }

        private void TeleportZombiesEnabled(object sender, RoutedEventArgs e)
        {
            if (TeleportZombiePositionCheckBox.IsChecked.GetValueOrDefault())
                TeleportZombiePositionCheckBox.IsChecked = false;

            _console.WriteLine("Teleport Zombies Too Crosshair Enabled", Brushes.Green);
            _teleportZombies = true;
        }

        private void TeleportZombiesDisable(object sender, RoutedEventArgs e)
        {
            _console.WriteLine("Teleport Zombies Disabled", Brushes.Green);
            _teleportZombies = false;
        }

        private void XpModiferEnabled(object sender, DragCompletedEventArgs e)
        {
            if (XpModiferCheckBox.IsChecked.GetValueOrDefault())
            {
                _console.WriteLine("XP Multiplier enabled", Brushes.Green);
                _core.XpMultiplier.PlayerXpMultiplier((float) XpModiferSlider.Value);
            }
        }

        private void XpModiferDisabled(object sender, RoutedEventArgs e)
        {
            _console.WriteLine("XP Multiplier disabled", Brushes.Green);
            _core.XpMultiplier.PlayerXpMultiplier(1f);
        }

        private void GunXpModiferEnabled(object sender, DragCompletedEventArgs e)
        {
            if (GunXpModiferCheckBox.IsChecked.GetValueOrDefault())
            {
                _console.WriteLine("XP Multiplier Started", Brushes.Green);
                _core.XpMultiplier.GunXpMultiplier((float) XpModiferSlider.Value);
            }
        }

        private void GunXpModiferDisabled(object sender, RoutedEventArgs e)
        {
            _console.WriteLine("XP Multiplier disabled", Brushes.Green);
            _core.XpMultiplier.GunXpMultiplier(1f);
        }

        private void InfraredEnable(object sender, RoutedEventArgs e)
        {
            _console.WriteLine("Infrared enabled", Brushes.Green);
            _core.MiscFeatures.ToggleInfraredVision();
        }

        private void InfraredDisable(object sender, RoutedEventArgs e)
        {
            _console.WriteLine("Infrared enabled", Brushes.Green);
            _core.MiscFeatures.ToggleInfraredVision();
        }

        private void RapidFireEnabled(object sender, RoutedEventArgs e)
        {
            _console.WriteLine("Rapid Fire enabled", Brushes.Green);
            _rapidFire = true;
        }

        private void RapidFireDisable(object sender, RoutedEventArgs e)
        {
            _console.WriteLine("Rapid Fire Disabled", Brushes.Green);
            _rapidFire = false;
        }

        private void HeadShotOnlyEnabled(object sender, RoutedEventArgs e)
        {
            _console.WriteLine("Head Shot Only Enabled", Brushes.Green);
            _critOnly = true;
            _core.MiscFeatures.CritOnly();
        }

        private void HeadShotOnlyDisable(object sender, RoutedEventArgs e)
        {
            _console.WriteLine("Head Shot Only Disabled", Brushes.Green);
            _critOnly = false;
            _core.MiscFeatures.CritOnly();
        }

        private void SetPosition(object sender, RoutedEventArgs e)
        {
            var position = _core.ZombieHack.SetPosition();
            PositionLabel.Content = $"Set Position: [{position.X},{position.Y},{position.Z}]";
        }

        private void TeleportZombiesPosEnabled(object sender, RoutedEventArgs e)
        {
            _console.WriteLine("Teleporting Zombies To Location Enabled", Brushes.Green);

            if (TeleportZombieCheckBox.IsChecked.GetValueOrDefault())
                TeleportZombieCheckBox.IsChecked = false;
            _teleportZombiesLocation = true;
        }

        private void TeleportZombiesPosDisabled(object sender, RoutedEventArgs e)
        {
            _console.WriteLine("Teleporting Zombies To Location Disable", Brushes.Green);
            _teleportZombiesLocation = false;
        }

        private void ChangeWeaponButton_Click(object sender, RoutedEventArgs e)
        {
            _console.WriteLine("Weapon Changed", Brushes.Green);
            var weapon = (KeyValuePair<string, int>) WeaponIdComboBox.SelectedItem;
            _core.MiscFeatures.SetWeapon(weapon.Value);
            MyWeaponLabel.Content = $"Weapon: {WeaponIdComboBox.Text}";
        }

        private void AutomaticSwitchEnable(object sender, RoutedEventArgs e)
        {
            _console.WriteLine("AutomaticSwitch Enabled", Brushes.Green);
            _automaticSwitch = true;
        }
        
        private void AutomaticSwitchDisabled(object sender, RoutedEventArgs e)
        {
            _console.WriteLine("AutomaticSwitch Disabled", Brushes.Green);
            _automaticSwitch = false;
        }
    }
}
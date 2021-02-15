namespace SaladeTomateOignon
{
    internal class Offsets
    {
        public static int PlayerBase = 0x10AA0BC8; /** Sig : 4C 8D 05 ? ? ? ? 41 8B 8C 98 ? ? ? ? 85 ? ? ? 83 F9 07 ? ? 48 98 41 3B 8C 80 ? ? ? ? 74 02 **/
        public static int ZMXPScaleBase = 0x10AC7BC0;
        public static int XPScaleBase = 0xFD2C250;
        
        public static class PlayerCompPtr
        {
            public static int ArraySizeOffset = 0xB900;
            public static int CurrentUsedWeaponID = 0x28;
            public static int SetWeaponID = 0xB0;
            public static int InfraredVision = 0xE66;
            public static int GodMode = 0xE67;
            public static int Ammo = 0x13D4;
            public static int Points = 0x5D04;
            public static int RunSpeed = 0x5C50;
            public static int RapidFire1 = 0xE6C;
            public static int RapidFire2 = 0xE80;
            public static int Name = 0x5BDA;
            public static int CritOffset = 0x10D6;
            public static int KillCount = 0x5CE8;
        }
        
        public class PlayerPedPtr
        {
            public static int ArraySizeOffset = 0x5F8;
            public static int Coords = 0x2D4;
            public static int HeadingZ = 0x34;
            public static int HeadingXY = 0x38;
        }

        public class ZombieBotListBase
        {
            public static int BotArraySizeOffset = 0x5F8;
            public static int BotHealth = 0x398;
            public static int BotMaxHealth = 0x39C;
            public static int Coords = 0x2D4;
        }

        public class ZombieGlobalClass
        {
            public static int ZombieLeftCount = 0x3C;
        }

        public class ZombieXpScaleBase
        {
            public static int XPGun = 0x30; //XPGun_Offset
            public static int XPUserReal = 0x28; //Real XPEP_RealAdd_Offset
        }
    }
}
namespace SaladeTomateOignon
{
    internal class Offsets
    {
        public static int PlayerBase = 0xFC297B8;

        /** Sig : 4C 8D 05 ? ? ? ? 41 8B 8C 98 ? ? ? ? 85 ? ? ? 83 F9 07 ? ? 48 98 41 3B 8C 80 ? ? ? ? 74 02 **/
        public static int ZMXPScaleBase = 0xFC517B0;

        /** Sig : 44 38 BC 30 ? ? ? ? 0F 84 ? ? ? ? 0F 57 C0 **/
        public static int TimeScaleBase = 0xECF9C74;

        public static class PlayerCompPtr
        {
            public static int ArraySizeOffset = 0xB830;

            /** Sig : 89 84 33 ? ? ? ? 48 ? B6 ? ? ? ? E8 ? ? ? ? 44 ? F8 ? CA **/
            public static int CurrentUsedWeaponID = 0x28;

            public static int SetWeaponID = 0xB0;
            public static int InfraredVision = 0xE66; //On=0x10|Off=0x0
            public static int GodMode = 0xE67;

            /** Sig :  **/
            public static int Ammo = 0x13D4;

            public static int Points = 0x5CE4;
            public static int RunSpeed = 0x5C30;
            public static int RapidFire1 = 0xE6C;
            public static int RapidFire2 = 0xE80;
            public static int Name = 0x5BDA;
            public static int JumpHeight = 0xFE63458; //gamebase + 0xFE63458 (pointer) + 0x130 (default value 39.0float)

            public static int CritOffset1 = 0x10cc;
            public static int CritOffset2 = 0x10d0;
            public static int CritOffset3 = 0x10e4;
            public static int CritOffset4 = 0x10e8;
            public static int CritOffset5 = 0x10c4;
            public static int CritOffset6 = 0x10c8;
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
            public static int XPUserFake = 0x20; //Fake XPEP_InGame_Offset
            public static int XPUserReal = 0x28; //Real XPEP_RealAdd_Offset
        }
    }
}
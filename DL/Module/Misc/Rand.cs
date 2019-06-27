using System;

namespace BaseFramework.DL.Module.Misc {
    public static class Rand {
        public static int SmallInt() => new Random().Next(UInt16.MaxValue);
        public static int Int() => new Random().Next();
        public static int IntRange(int min, int max) => new Random().Next(min, max);
        
        public static decimal SmallDecimal() => 0.0001M * new Random().Next(UInt16.MaxValue);
    }
}
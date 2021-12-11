namespace SmartPoint.AssetAssistant.UnityExtensions
{
    public struct FloatBits
    {
        private const float FP_EPSILON = 1E-05f;
        private const int FP_SIGN_SHIFT = 31;
        private const int FP_SIGN_BITS = -2147483648;
        private float fp;
        private int bits;
        private uint ubits;

        public FloatBits(float value)
        {
            fp = value;
            bits = 0;
            ubits = 0;
        }

        public FloatBits(int value)
        {
            fp = 0;
            bits = value;
            ubits = 0;
        }

        public FloatBits(uint value)
        {
            fp = 0;
            bits = 0;
            ubits = value;
        }

        public static implicit operator float(FloatBits fpBits) => new float();

        public static implicit operator FloatBits(float fp) => new FloatBits(fp);

        public static implicit operator FloatBits(int bits) => new FloatBits(bits);

        public static implicit operator FloatBits(uint ubits) => new FloatBits(ubits);

        public static float ToFloat(int bits) => new float();

        public static float ToFloat(uint bits) => new float();

        public static int ToInt(float value) => new int();

        public static uint ToUInt(float value) => new uint();

        public override string ToString() => (string) null;

        public FloatBits Absolute() => new FloatBits();

        public bool IsInRange(float low, float high) => new bool();
    }
}

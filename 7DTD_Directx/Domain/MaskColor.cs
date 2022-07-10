namespace _7DTD_Directx.Domain
{
    public struct MaskColor
    {
        public byte? A { get; set; }
        public byte? R { get; set; }
        public byte? G { get; set; }
        public byte? B { get; set; }

        public MaskColor(byte? a, byte? r, byte? g, byte? b)
        {
            A = a;
            R = r;
            G = g;
            B = b;
        }
    }
}

namespace Vidly.Models
{
    public class MembershipType
    {
        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
        public static readonly byte Monthly = 2;
        public static readonly byte Quarterly = 3;
        public static readonly byte Yearly = 4;

        public byte Id { get; set; }
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonth { get; set; }
        public byte DiscountRate { get; set; }
    }
}

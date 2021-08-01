using System;

namespace stonk
{
    public class Bar
    {
        public String symbol { get; set; }
        public Decimal open { get; set; }
        public Decimal high { get; set; }
        public Decimal low { get; set; }
        public Decimal close { get; set; }
        public Decimal volume { get; set; }
        public DateTime time { get; set; }
    }
}
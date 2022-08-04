using Sirena.Taxi.PseudoProviders.Models.Internal;

namespace Sirena.Taxi.PseudoProviders.Models.Yandex
{
    public class PriceResponse: IPriceResponse
    {
        public string currency { get; set; }
        public float distance { get; set; }
        public Option[] options { get; set; }
        public float time { get; set; }
    }

    public class Option
    {
        public int class_level { get; set; }
        public string class_name { get; set; }
        public string class_text { get; set; }
        public int min_price { get; set; }
        public int price { get; set; }
        public string price_text { get; set; }
        public float waiting_time { get; set; }
    }

}

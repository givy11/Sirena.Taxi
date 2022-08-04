using Sirena.Taxi.PseudoProviders.Models.Internal;

namespace Sirena.Taxi.PseudoProviders.Models.IWay
{
    public class PriceResponse: IPriceResponse
    {
        public PriceResult[] result { get; set; }
        public object error { get; set; }
    }

    public class PriceResult
    {
        public string price_uid { get; set; }
        public int price_id { get; set; }
        public int price { get; set; }
        public int price_rub { get; set; }
        public Reverse_Price reverse_price { get; set; }
        public string currency { get; set; }
        public int service_id { get; set; }
        public Car_Class car_class { get; set; }
        public int allowable_subaddress { get; set; }
        public int price_subaddress { get; set; }
        public int cancellation_time { get; set; }
        public int type { get; set; }
        public bool payed_road { get; set; }
        public string[] blackout_date { get; set; }
        public int allowable_time { get; set; }
        public object id_custom_price { get; set; }
        public int minimum_duration { get; set; }
        public Start_Place start_place { get; set; }
        public Finish_Place finish_place { get; set; }
        public bool flexible_tariff { get; set; }
        public bool flexible_tariff_agreement { get; set; }
        public Additional_Services additional_services { get; set; }
        public Additional_Service_Id additional_service_id { get; set; }
    }

    public class Reverse_Price
    {
        public int price_id { get; set; }
        public int price { get; set; }
    }

    public class Car_Class
    {
        public int car_class_id { get; set; }
        public string title { get; set; }
        public string[] models { get; set; }
        public string photo { get; set; }
        public int capacity { get; set; }
    }

    public class Start_Place
    {
        public int place_id { get; set; }
        public string title { get; set; }
        public int type { get; set; }
        public string type_title { get; set; }
        public string[] terminal { get; set; }
        public Declension_Titles declension_titles { get; set; }
    }

    public class Declension_Titles
    {
        public object nom { get; set; }
        public object gen { get; set; }
        public object acc { get; set; }
    }

    public class Finish_Place
    {
        public int place_id { get; set; }
        public string title { get; set; }
        public int type { get; set; }
        public string type_title { get; set; }
        public string[] terminal { get; set; }
        public Declension_Titles1 declension_titles { get; set; }
    }

    public class Declension_Titles1
    {
        public object nom { get; set; }
        public object gen { get; set; }
        public object acc { get; set; }
    }

    public class Additional_Services
    {
        public int id { get; set; }
        public int additional_service_id { get; set; }
        public string price { get; set; }
        public string name { get; set; }
        public string uid { get; set; }
        public bool default_include { get; set; }
        public string slug { get; set; }
        public string type { get; set; }
        public string category { get; set; }
    }

    public class Additional_Service_Id
    {
        public int id { get; set; }
        public object additional_service_id { get; set; }
        public string uid { get; set; }
        public bool default_include { get; set; }
        public string slug { get; set; }
        public string currency { get; set; }
        public string type { get; set; }
        public string category { get; set; }
    }
}

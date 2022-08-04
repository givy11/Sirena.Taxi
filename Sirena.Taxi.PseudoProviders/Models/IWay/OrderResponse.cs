using Sirena.Taxi.PseudoProviders.Models.Internal;

namespace Sirena.Taxi.PseudoProviders.Models.IWay
{
    public class OrderResponse: IOrderResponse
    {
        public OrderResult[] result { get; set; }
        public object error { get; set; }
    }

    public class OrderResult
    {
        public int order_id { get; set; }
        public int transaction { get; set; }
        public string booker_number { get; set; }
        public int price { get; set; }
        public int payable_status { get; set; }
        public int service_id { get; set; }
        public string currency { get; set; }
        public int status { get; set; }
        public Passenger[] passengers { get; set; }
        public Customer customer { get; set; }
        public int additional_change_itinerary { get; set; }
        public int additional_wait { get; set; }
        public int fare_on_toll_road { get; set; }
        public Send_Params send_params { get; set; }
    }

    public class Customer
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }

    public class Send_Params
    {
        public bool send_client_voucher { get; set; }
        public bool send_admin_voucher { get; set; }
        public bool send_client_doc { get; set; }
        public bool send_admin_doc { get; set; }
    }

    public class Passenger
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }

}

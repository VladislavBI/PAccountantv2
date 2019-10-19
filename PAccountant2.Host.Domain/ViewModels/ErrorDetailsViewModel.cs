using Newtonsoft.Json;

namespace PAccountant2.Host.Domain.ViewModels
{
    public class ErrorDetailsViewModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

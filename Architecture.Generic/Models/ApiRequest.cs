namespace InspiralThoughtsAPI.Models.ApiModel
{
    public class ApiRequest<T>
    {
        public string Token { get; set; }
        public string Key { get; set; }
        public T Data { get; set; }
    }

    public class ApiRequest
    {
        public string Token { get; set; }
        public string Key { get; set; }
    }

    public class IdModel
    {
        public long Id { get; set; }
    }
}
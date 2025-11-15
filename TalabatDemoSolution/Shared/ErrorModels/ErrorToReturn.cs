
namespace Shared.ErrorModels
{
    public class ErrorToReturn
    {
        public string Message { get; set; } = null!;
        public int StatusCode { get; set; }
        public List<string>? Errors { get; set; }
    }
}

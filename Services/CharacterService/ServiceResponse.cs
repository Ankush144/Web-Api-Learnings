using Web_Api_Learnings.Models;

namespace Web_Api_Learnings.Services.CharacterService
{
    internal class ServiceResponse
    {

        public bool Status { get; set; }
        public string Message { get; set; }
        public List<Character> Data { get; set; }
    }
}
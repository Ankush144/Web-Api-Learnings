using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api_Learnings.Models;

namespace Web_Api_Learnings.Dtos.Character
{
    public class GetCharacterDto
    {
            public string Name { get; set; } = "Frodo";
            public int HitPoints { get; set; } =100;
            public int Strength { get; set; } =10;
            public int Defense { get; set; }=10;
            public int Intelligence { get; set; }=10;

            public RpgClass Class { get; set; } = RpgClass.Knight;

        public static implicit operator GetCharacterDto(List<Models.Character> v)
        {
            throw new NotImplementedException();
        }

        public static implicit operator GetCharacterDto(ServiceResponse<GetCharacterDto> v)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web_Api_Learnings.Dtos.Character;
using Web_Api_Learnings.Models;

namespace Web_Api_Learnings.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int Id);
        Task<ServiceResponse<List<GetCharacterDto>>> GetCharacters();
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto X);
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto X);
        Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int Id);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web_Api_Learnings.Dtos.Character;
using Web_Api_Learnings.Models;
using Web_Api_Learnings.Services.CharacterService;

namespace Web_Api_Learnings.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController:ControllerBase
    {

        public ICharacterService _characterService { get; }

        public CharacterController(ICharacterService characterService)
        { 
            _characterService = characterService;
        }
        [HttpGet("GetSingle")]
        public async Task<ActionResult<Character>> GetCharacterById(int Id)
        {
            var data = await _characterService.GetCharacterById(Id);
            return Ok(data);
        }
        [HttpGet("GetCharacter")]
        public async Task<ActionResult<List<Character>>> GetCharacters()
        {
            var data = await _characterService.GetCharacters();
            return Ok(data);
        }
        [HttpPost("AddCharacter")]
        public async Task<ActionResult<Character>> AddCharacter(AddCharacterDto newCharacter)
        {
           var data = await  _characterService.AddCharacter(newCharacter);
           return Ok(data);
        }
        [HttpPut("UpdateCharacter")]
        public async Task<ActionResult<UpdateCharacterDto>> GetCharacterDto(UpdateCharacterDto X)
        {
            var data =await  _characterService.UpdateCharacter(X);
            return Ok(data);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var data =await _characterService.DeleteCharacter(id);
            return Ok(data);
        }
    }
}
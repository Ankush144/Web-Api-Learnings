using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web_Api_Learnings.Dtos.Character;
using Web_Api_Learnings.Models;

namespace Web_Api_Learnings.Services.CharacterService
{
    public class CharacterService : ICharacterService
    { 
        public IMapper _mapper;
        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }
        private static List<Character> CharacterList = new List<Character>{
            new Character(),
            new Character(){Id=1,Name="Sam"}
        };



        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto X)
        {
             var data  = _mapper.Map<Character>(X);
             data.Id = CharacterList.Max(X=>X.Id) + 1;
             CharacterList.Add(data); 

             var responces = _mapper.Map<List<GetCharacterDto>>(CharacterList);
             return new ServiceResponse<List<GetCharacterDto>> {Status=true,Message="",Data=responces};
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetCharacters()
        {
            var charactersListDto = _mapper.Map<List<GetCharacterDto>>(CharacterList);
            return new ServiceResponse<List<GetCharacterDto>> {Status=true,Message="",Data=charactersListDto };
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int Id)
        {
            var character =  CharacterList.FirstOrDefault(x => x.Id == Id);
            var chara = _mapper.Map<GetCharacterDto>(character);
            return new ServiceResponse<GetCharacterDto>{Status=true,Message="",Data=chara};
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto X)
        {
            var characterToBeUpdated = CharacterList.FirstOrDefault(c=>c.Id==X.Id);
            _mapper.Map(X,characterToBeUpdated); // this is how we can use map to update the object`
            ServiceResponse<GetCharacterDto> res = new ServiceResponse<GetCharacterDto>();
            res.Data  = _mapper.Map<GetCharacterDto>(characterToBeUpdated);
            res.Message = "";
            res.Status  = true;
           return res;
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
          var data = CharacterList.First(c=>c.Id==id);
          CharacterList.Remove(data);
          var res = _mapper.Map<List<GetCharacterDto>>(CharacterList);
          return new ServiceResponse<List<GetCharacterDto>>(){Status=true,Message="",Data=res};
        }
    }
}
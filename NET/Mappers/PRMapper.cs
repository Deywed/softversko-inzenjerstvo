using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.Domain;
using NET.Models;

namespace NET.Mappers
{
    static class PRMapper
    {
        public static PRDTO ToDto(this PR pr)
        {
            return new PRDTO
            {
                Id = pr.Id,
                ExerciseId = pr.ExerciseId,
                UserId = pr.UserId,
                Weight = pr.Weight,
                Date = pr.Date,
            };
        }

        public static PR ToEntity(this CreatePRDTO prDto)
        {
            return new PR
            {
                ExerciseId = prDto.ExerciseId,
                UserId = prDto.UserId,
                Weight = prDto.Weight,
                Date = prDto.Date,
            };
        }
        public static void UpdateEntity(this PR pr, UpdatePRDTO updateDto)
        {
            pr.Weight = updateDto.Weight ?? pr.Weight;
            pr.Date = updateDto.Date ?? pr.Date;
        }
    }
}
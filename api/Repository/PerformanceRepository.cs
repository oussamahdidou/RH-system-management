using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Abscence;
using api.Dtos.Conges;
using api.Dtos.Heuresupplimentaire;
using api.helpers;
using api.interfaces;
using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class PerformanceRepository : IPerformanceRepository
    {
        private readonly ApiDbContext apiDbContext;
        private readonly ICongesRepository congesRepository;
        public PerformanceRepository(ApiDbContext apiDbContext, ICongesRepository congesRepository)
        {
            this.apiDbContext = apiDbContext;
            this.congesRepository = congesRepository;
        }
        public async Task<Abscence> AddAbscence(CreateAbscenceDto createAbscenceDto)
        {

            if (await congesRepository.EnConges(new EnCongesDto() { EmployerId = createAbscenceDto.EmployerId }))
            {
                return null;

            }
            Abscence abscence = new Abscence()
            {
                AppUserId = createAbscenceDto.EmployerId,
                Date = createAbscenceDto.dateTime,
            };
            await apiDbContext.Abscences.AddAsync(abscence);
            await apiDbContext.SaveChangesAsync();
            return abscence;

        }

        public async Task<Heuresupplimentaires> AddHeuressupplimentaires(CreateHeuresupplimentaire createHeuresupplimentaire)
        {
            Heuresupplimentaires heuresupplimentaires = new Heuresupplimentaires()
            {
                AppUserId = createHeuresupplimentaire.EmployerId,
                DateTime = createHeuresupplimentaire.dateTime,
            };
            await apiDbContext.Heuresupplimentaires.AddAsync(heuresupplimentaires);
            await apiDbContext.SaveChangesAsync();
            return heuresupplimentaires;
        }

        public async Task<Abscence> JustifyAbscence(int AbscenceId)
        {
            Abscence? abscence = await apiDbContext.Abscences.FirstOrDefaultAsync(x => x.Id == AbscenceId);
            if (abscence == null)
            {
                return null;
            }
            abscence.Status = Abscencestatues.Justifier;
            await apiDbContext.SaveChangesAsync();
            return abscence;
        }

    }
}
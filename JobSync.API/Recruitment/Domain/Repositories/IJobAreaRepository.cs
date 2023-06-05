﻿using JobSync.API.Recruitment.Domain.Models;

namespace JobSync.API.Recruitment.Domain.Repositories;

public interface IJobAreaRepository
{
    Task<IEnumerable<JobArea>>ListAsync();
    Task AddAsync(JobArea jobArea);
    Task<JobArea> FindByIdAsync(int id);
    void Update(JobArea jobArea);
    void Remove(JobArea jobArea);
}
using DAL.Api;
using DAL.Exceptions;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class JobService : IJob
    {
        IJobOffers jobOffersService;
        dbClass dataBase;

        public JobService(IJobOffers jobOffersService, dbClass dataBase)
        {
            this.jobOffersService = jobOffersService;
            this.dataBase = dataBase;
        }
        public Job GetJobByCode(int code)
        {
            Job job = dataBase.Jobs.FirstOrDefault(j => j.Code == code);
            if (job == null)
                throw new JobNotFoundException(code);
            return job;
        }
        public void AddJob(Job job)
        {
            if (dataBase.Jobs.FirstOrDefault(j => j.Code == job.Code) != null)
               throw new JobAlreadyExistsException(job.Code);
            dataBase.Jobs.Add(job);
            dataBase.SaveChanges();
            jobOffersService.AddCandidates(job);
        }

        public ICollection<JobOffer> FindMatchingCandidates(int code)
        {
            return jobOffersService.FindCandidatesByJobCode(code);
        }

        public void NotSeekingWorkers(int code)
        {
            if (dataBase.Jobs.FirstOrDefault(j => j.Code == code) == null)
               throw new JobNotFoundException(code);
            dataBase.Jobs.FirstOrDefault(j=>j.Code == code).JobOffers.Clear();
            dataBase.Jobs.Remove(dataBase.Jobs.FirstOrDefault(j => j.Code == code));
            dataBase.SaveChanges();
        }
    }
}

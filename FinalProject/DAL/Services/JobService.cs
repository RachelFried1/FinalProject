using DAL.Api;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class JobService :IJob
    {
        public List<Job> Jobs { get; set; }
        IDalManager _dalManager;
        dbClass database;

        public JobService(IDalManager dalManager , dbClass database)
        {
            _dalManager = dalManager;
            this.database = database;
        }
        public bool AddJob(Job job)
        {
           // Jobs.Add(job);
            database.Jobs.add(job);
            database.Jobs.save();

            _dalManager.JobOffersManager.AddCandidates(job);
            return true;
        }

        public List<JobSeeker> FindMatchingCandidates(int code)
        {
            List<JobSeeker> candidates = new List<JobSeeker>();
            candidates = _dalManager.JobOffersManager.FindCandidatesByJobCode(code);
            return candidates;
        }

        public bool NotSeekingWorkers(int code)
        {
            foreach (JobOffer offer in _dalManager.JobOffersManager.JobOffers)
            {
                if (offer.JobCode == code)
                {
                    _dalManager.JobOffersManager.JobOffers.Remove(offer);
                }
            }
            return Jobs.Remove(Jobs.FirstOrDefault(j=>j.Code == code));
        }
    }
}

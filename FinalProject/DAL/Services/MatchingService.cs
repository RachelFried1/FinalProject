using DAL.Models.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class MatchingService
    {
        public double CalculateMatchingScore(JobSeeker seeker, Job job)
        {
            if (seeker == null || job == null) return 0;

            double score = 0;
            int totalWeight = 0;

            int fieldWeight = 30;
            if (seeker.Field == job.Field)
                score += fieldWeight;
            totalWeight += fieldWeight;

            int degreeWeight = 20;
            if (!job.RequiresDegree || seeker.HasDegree)
                score += degreeWeight;
            totalWeight += degreeWeight;

            int hoursWeight = 20;
            if (seeker.DailyWorkHours + 2 >= job.WorkHours)
                score += hoursWeight;
            totalWeight += hoursWeight;

            int experienceWeight = 30;
            double experienceRatio = (double)seeker.YearsOfExperience / job.MinYearsExperience;
            experienceRatio = Math.Min(experienceRatio, 1.0);
            score += experienceRatio * experienceWeight;
            totalWeight += experienceWeight;

            return score / totalWeight;
        }

    }
}
using DAL.Models.models;
using System;

namespace DAL.Services
{
    public class MatchingService
    {
        public double CalculateMatchingScore(JobSeeker seeker, Job job)
        {
            if (seeker == null || job == null)
                return 0;
            if (seeker.Field != job.Field)
                return 0;

            double score = 0;
            int totalWeight = 0;

            int degreeWeight = 20;
            if (!job.RequiresDegree || seeker.HasDegree)
                score += degreeWeight;
            totalWeight += degreeWeight;

            int hoursWeight = 20;
            if (seeker.DailyWorkHours >= job.WorkHours)
            {
                score += hoursWeight;
            }
            else if (seeker.DailyWorkHours + 2 >= job.WorkHours)
            {
                score += hoursWeight / 2.0;
            }
            totalWeight += hoursWeight;

            int experienceWeight = 40;
            if (job.MinYearsExperience > 0)
            {
                double experienceRatio = (double)seeker.YearsOfExperience / job.MinYearsExperience;
                experienceRatio = Math.Min(experienceRatio, 1.0); // Cap at 100%
                score += experienceRatio * experienceWeight;
            }
            else
            {
                score += experienceWeight;
            }
            totalWeight += experienceWeight;

            return score / totalWeight;
        }
    }
}
using DAL.Models.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


        namespace DAL.Services
    {
        public static class MatchingService
        {
            public static double CalculateMatchingScore(JobSeeker seeker, Job job)
            {
                if (seeker == null || job == null) return 0;

                double score = 0;
                int totalWeight = 0;

                // Field match
                int fieldWeight = 30;
                if (seeker.Field == job.Field)
                    score += fieldWeight;
                totalWeight += fieldWeight;

                // Degree match
                int degreeWeight = 20;
                if (!job.RequiresDegree || seeker.HasDegree)
                    score += degreeWeight;
                totalWeight += degreeWeight;

                // Work hours flexibility
                int hoursWeight = 20;
                if (seeker.DailyWorkHours + 2 >= job.WorkHours)
                    score += hoursWeight;
                totalWeight += hoursWeight;

                // Experience ratio
                int experienceWeight = 30;
                double experienceRatio = (double)seeker.YearsOfExperience / job.MinYearsExperience;
                experienceRatio = Math.Min(experienceRatio, 1.0);
                score += experienceRatio * experienceWeight;
                totalWeight += experienceWeight;

                return score / totalWeight; // Normalized between 0 and 1
            }
        }
    }


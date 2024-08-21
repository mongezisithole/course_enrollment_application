using course_enrollment_application.Data.Context;
using course_enrollment_application.Data.Entities;
using course_enrollment_application.Repositories;
using course_enrollment_application.Shared.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_enrollment_application.Repository.Implementations
{
    public class AcademicYearRepo: IAcademicYearRepo
    {
        public readonly DataContext _context;

        public AcademicYearRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAcademicYear(CreateAcademicYearDetails academicYearDetails)
        {
            try
            {
                var academicYear = new AcademicYear
                {
                    DateCreated = DateTime.Now,
                    Description = academicYearDetails.Description,
                    Name = academicYearDetails.Name,
                    EndDate = academicYearDetails.EndDate,
                    StartDate = academicYearDetails.StartDate,
                };

                await _context.AcademicYears.AddAsync(academicYear);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                //Log error
                throw;
            }
        }

        public async Task<int> GetCurrentAcademicYear()
        {
            var activeYear = await _context.AcademicYears.FirstOrDefaultAsync(o => o.IsCurrentYear);

            return activeYear?.Id ?? 0;
        }

        public async Task<bool> SetCurrentAcademicYear(int academicYearId)
        {
            try
            {
                var year = await _context.AcademicYears.FirstOrDefaultAsync(o => o.Id == academicYearId);

                if(year == null) return false; 

                var activeYears = await _context.AcademicYears.Where(o => o.IsCurrentYear).ToListAsync();

                foreach (var activeYear in activeYears)
                {
                    activeYear.IsCurrentYear = false;
                    activeYear.LastModifiedDate = DateTime.Now;
                }

                year.IsCurrentYear = true;
                year.LastModifiedDate = DateTime.Now;
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                //Log error
                throw;
            }
        }
    }
}

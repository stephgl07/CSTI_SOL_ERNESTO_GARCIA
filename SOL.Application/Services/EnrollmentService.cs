using SOL.Application.Mappers;
using SOL.Domain.Models.BusinessEntities;
using RES = SOL.Domain.Models.DataTransferObjects.Enrollments.Response;
using REQ = SOL.Domain.Models.DataTransferObjects.Enrollments.Request;
using SOL.Domain.Models.DataTransferObjects.Students;
using SOL.Domain.Services.Enrollments;
using SOL.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOL.Domain.Models.Exceptions;

namespace SOL.Application.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly EnrollmentMapper _enrollmentMapper;
        private readonly IUnitOfWork _unitOfWork;

        public EnrollmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _enrollmentMapper = new EnrollmentMapper();
        }

        public async Task<int> CancelEnrollment(int EnrollmentId)
        {
            await _unitOfWork.Enrollment.CancelEnrollment(EnrollmentId);
            await _unitOfWork.SaveChangesAsync();

            return 1;
        }

        public async Task<RES.RegisterEnrollmentDTO> EnrollStudent(REQ.RegisterEnrollmentDTO enrollmentDTO)
        {
            // Check Section availability
            var sectionAvailable = await _unitOfWork.Section.CheckAvailability(enrollmentDTO.SectionID);
            if(!sectionAvailable) throw new BusinessException(message: "La sección no se encuentra disponible.");

            // Check if Student is already enroll on the same course
            var totalCredits = await _unitOfWork.Student.CheckTotalCredits(enrollmentDTO.StudentDNI);
            var courseCredits = await _unitOfWork.Course.GetCredits(enrollmentDTO.CourseID);
            if ((totalCredits + courseCredits) > 5) throw new BusinessException(message: "No se pudo matricular porque el Alumno superaría los 5 créditos permitidos");

            // Check if Student is already enroll on the same course
            var isAlreadyEnrolled = await _unitOfWork.Student.CheckIfEnrolled(enrollmentDTO.StudentDNI, enrollmentDTO.CourseID);
            if (isAlreadyEnrolled) throw new BusinessException(message: "No se pudo matricular porque el Alumno ya se encuentra matriculado en el mismo curso");

            // Check Vacancies
            var courseSectionVacancy = await _unitOfWork.CourseSectionVacancy.GetByCourseSection(enrollmentDTO.CourseID, enrollmentDTO.SectionID);
            if(courseSectionVacancy.VACANCIES <= 0) throw new BusinessException(message: "No se pudo matricular por falta de vacantes.");

            var newEnrollment = new ENROLLMENTS()
            {
                STUDENTDNI = enrollmentDTO.StudentDNI,
                COURSEID = enrollmentDTO.CourseID,
                SECTIONID = enrollmentDTO.SectionID,
                ENROLLMENTTYPE = enrollmentDTO.EnrollmentType,
                STATUS = true,
                ENROLLMENTDATE = DateTime.Now
            };
            
            // Enroll student
            int idNewEnrollment = await _unitOfWork.Enrollment.Create(newEnrollment);
            
            // Decrease number of vacancies
            courseSectionVacancy.VACANCIES--;

            // Save all changes
            await _unitOfWork.SaveChangesAsync();

            var responseMapped = _enrollmentMapper.MapRegisterEnrollment(idNewEnrollment);
            return responseMapped;

        }

        public async Task<IEnumerable<RES.GetAllEnrollmentsDTO>> GetAll()
        {
            IEnumerable<ENROLLMENTS> listEnrollments = await _unitOfWork.Enrollment.GetAll();
            var responseMapped = _enrollmentMapper.MapGetAllEnrollments(listEnrollments);
            return responseMapped;
        }

        public async Task<IEnumerable<RES.GetReportDTO>> GetReport()
        {
            IEnumerable<ENROLLMENTS> listEnrollments = await _unitOfWork.Enrollment.GetAllInfoEnrollment();
            var responseMapped = _enrollmentMapper.MapGetReport(listEnrollments);
            return responseMapped;
        }

    }
}

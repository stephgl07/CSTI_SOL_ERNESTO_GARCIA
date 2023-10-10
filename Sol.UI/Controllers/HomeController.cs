using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using SOL.Domain.Wrappers;
using Sol.UI.Util;
using SOL.Domain.Models.DataTransferObjects.Students;
using ENR_RES = SOL.Domain.Models.DataTransferObjects.Enrollments.Response;
using ENR_REQ = SOL.Domain.Models.DataTransferObjects.Enrollments.Request;
using SOL.Domain.Models.DataTransferObjects.Sections.Response;
using SOL.Domain.Models.DataTransferObjects.Courses.Response;
using System.Text;
using SOL.Domain.Dictionaries;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Net;

namespace Sol.UI.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            List<ENR_RES.GetReportDTO> enrollmentReport = new List<ENR_RES.GetReportDTO>();
            using (HttpClient client = new HttpClient())
            {
                string url = ApiEndpoints.GetReportEnrollmentEndpoint();
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var reportDTO = JsonConvert.DeserializeObject<ApiResponse<List<ENR_RES.GetReportDTO>>>(content);
                    enrollmentReport = reportDTO.Data;
                }
                else
                {
                    // Something else
                }
            }

            return View(enrollmentReport);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public async Task<ActionResult> CancelEnrollment(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ENR_RES.GetReportDTO enrollment = new ENR_RES.GetReportDTO();
            using (HttpClient client = new HttpClient())
            {
                string url = ApiEndpoints.GetReportEnrollmentEndpoint();
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var reportDTO = JsonConvert.DeserializeObject<ApiResponse<List<ENR_RES.GetReportDTO>>>(content);
                    enrollment = reportDTO.Data.Find(r => r.EnrollmentId == id);
                }
                else
                {
                    // Something else
                }
            }
            return View(enrollment);
        }

        // POST: ENROLLMENTS/Delete/5
        [HttpPost, ActionName("CancelEnrollment")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(decimal id)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = ApiEndpoints.PostEnrollStudent(); // Reemplaza con tu URL

                HttpResponseMessage response = await client.PutAsync(url + "?EnrollmentId=" + id, null);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var responseEnroll = JsonConvert.DeserializeObject<ApiResponse<int>>(content);

                    TempData["IsSuccess"] = responseEnroll.Succeeded;
                    TempData["MessageAlert"] = responseEnroll.Message;
                    TempData["MessageAlertDetails"] = responseEnroll.ErrorDetails;
                }
                else
                {
                    TempData["IsSuccess"] = false;
                }
                TempData["ActionTerminated"] = true;

                return RedirectToAction("Index");
            }
        }

        public async Task<ActionResult> Create()
        {
            var cachedData = HttpContext.Cache["ViewBagData"] as CacheData;

            if (cachedData == null)
            {
                cachedData = await LoadDataForCache();
                HttpContext.Cache["ViewBagData"] = cachedData;
            }

            ViewBag.SECTIONS = cachedData.Sections;
            ViewBag.STUDENTS = cachedData.Students;
            ViewBag.COURSES = cachedData.Courses;
            ViewBag.EnrollmentTypes = cachedData.EnrollmentTypes;

            return View();
        }

        public async Task<IEnumerable<GetAllSectionsDTO>> GetAllActiveSections()
        {
            List<GetAllSectionsDTO> listSections = new List<GetAllSectionsDTO>();
            using (HttpClient client = new HttpClient())
            {
                string url = ApiEndpoints.GetAllActiveSectionsEndpoint();
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var reportDTO = JsonConvert.DeserializeObject<ApiResponse<List<GetAllSectionsDTO>>>(content);
                    listSections = reportDTO.Data;
                }
                else
                {
                    // Something else
                }
            }

            return listSections;
        }

        public async Task<IEnumerable<GetAllStudentsDTO>> GetAllActiveStudents()
        {
            List<GetAllStudentsDTO> listSections = new List<GetAllStudentsDTO>();
            using (HttpClient client = new HttpClient())
            {
                string url = ApiEndpoints.GetAllActivesStudentsEndpoint();
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var reportDTO = JsonConvert.DeserializeObject<ApiResponse<List<GetAllStudentsDTO>>>(content);
                    listSections = reportDTO.Data;
                }
                else
                {
                    // Something else
                }
            }

            return listSections;
        }

        public async Task<IEnumerable<GetAllCoursesDTO>> GetAllCourses()
        {
            List<GetAllCoursesDTO> listSections = new List<GetAllCoursesDTO>();
            using (HttpClient client = new HttpClient())
            {
                string url = ApiEndpoints.GetAllCoursesEndpoint();
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var reportDTO = JsonConvert.DeserializeObject<ApiResponse<List<GetAllCoursesDTO>>>(content);
                    listSections = reportDTO.Data;
                }
                else
                {
                    // Something else
                }
            }

            return listSections;
        }

        [HttpPost]
        public async Task<ActionResult> Create(ENR_REQ.RegisterEnrollmentDTO enrollmentDTO)
        {
            if (ModelState.IsValid)
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = ApiEndpoints.PostEnrollStudent(); // Reemplaza con tu URL
                    var jsonContent = JsonConvert.SerializeObject(enrollmentDTO);
                    var requestContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, requestContent);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        var responseEnroll = JsonConvert.DeserializeObject<ApiResponse<ENR_RES.RegisterEnrollmentDTO>>(content);

                        TempData["IsSuccess"] = responseEnroll.Succeeded;
                        TempData["MessageAlert"] = responseEnroll.Message;
                        TempData["MessageAlertDetails"] = responseEnroll.ErrorDetails;
                    }
                    else
                    {
                        TempData["IsSuccess"] = false;
                    }
                    TempData["ActionTerminated"] = true;
                }
            }
            var cachedData = HttpContext.Cache["ViewBagData"] as CacheData;

            ViewBag.SECTIONS = cachedData.Sections;
            ViewBag.STUDENTS = cachedData.Students;
            ViewBag.COURSES = cachedData.Courses;
            ViewBag.EnrollmentTypes = cachedData.EnrollmentTypes;

            return View(enrollmentDTO);
        }

        private async Task<CacheData> LoadDataForCache()
        {
            var sections = await GetAllActiveSections();
            var students = await GetAllActiveStudents();
            var courses = await GetAllCourses();

            return new CacheData
            {
                Sections = new SelectList(sections, "SectionId", "SectionName"),
                Students = new SelectList(students, "DNI", "CompleteName"),
                Courses = new SelectList(courses, "CourseId", "CourseDescription"),
                EnrollmentTypes = new SelectList(EnrollmentOptions.EnrollmentTypes, "Key", "Value")
            };
        }

        public async Task<ActionResult> GetReportEnrollment()
        {
            List<ENR_RES.GetReportDTO> enrollmentReport = new List<ENR_RES.GetReportDTO>();
            using (HttpClient client = new HttpClient())
            {
                string url = ApiEndpoints.GetReportEnrollmentEndpoint();
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var reportDTO = JsonConvert.DeserializeObject<ApiResponse<List<ENR_RES.GetReportDTO>>>(content);
                    enrollmentReport = reportDTO.Data;
                    return DownloadExcel(enrollmentReport);
                }
            }

            return View();
        }

        public ActionResult DownloadExcel(List<ENR_RES.GetReportDTO> listaDeDatos)
        {
            try
            {
                using (ExcelPackage package = new ExcelPackage())
                {
                    // Create worksheet
                    var worksheet = package.Workbook.Worksheets.Add("Reporte");

                    // Set headers
                    worksheet.Cells["A1"].Value = "ID MATRICULA";
                    worksheet.Cells["B1"].Value = "CÓDIGO ALUMNO";
                    worksheet.Cells["C1"].Value = "NOMBRES";
                    worksheet.Cells["D1"].Value = "APELLIDOS";
                    worksheet.Cells["E1"].Value = "ID CURSO";
                    worksheet.Cells["F1"].Value = "DESCRIPCIÓN DE CURSO";
                    worksheet.Cells["G1"].Value = "CRÉDITOS";
                    worksheet.Cells["H1"].Value = "NOMBRE DE SECCIÓN";
                    worksheet.Cells["I1"].Value = "TIPO MATRÍCULA";
                    worksheet.Cells["J1"].Value = "FECHA MATRÍCULA";
                    worksheet.Cells["K1"].Value = "FECHA ANULACIÓN";

                    // haders config
                    using (var range = worksheet.Cells["A1:K1"])
                    {
                        range.Style.Font.Bold = true;
                        range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                    }

                    // Set data
                    int rowNum = 2;
                    foreach (var item in listaDeDatos)
                    {
                        worksheet.Cells["A" + rowNum].Value = item.EnrollmentId;
                        worksheet.Cells["B" + rowNum].Value = item.StudentCode;
                        worksheet.Cells["C" + rowNum].Value = item.StudentNames;
                        worksheet.Cells["D" + rowNum].Value = item.StudentLastNames;
                        worksheet.Cells["E" + rowNum].Value = item.CourseId;
                        worksheet.Cells["F" + rowNum].Value = item.CourseDescription;
                        worksheet.Cells["G" + rowNum].Value = item.CreditHours;
                        worksheet.Cells["H" + rowNum].Value = item.SectionName;
                        worksheet.Cells["I" + rowNum].Value = item.EnrollmentType;
                        worksheet.Cells["J" + rowNum].Value = item.EnrollmentDate;
                        worksheet.Cells["K" + rowNum].Value = item.EnrollmentCancelationDate;
                        rowNum++;
                    }

                    // Widht and height of the cells
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                    foreach (var cell in worksheet.Cells[worksheet.Dimension.Address])
                    {
                        cell.Style.WrapText = true; // Envolver texto si es necesario
                    }

                    // Save file in memory
                    byte[] fileBytes = package.GetAsByteArray();
                    string actualDate = DateTime.Now.ToString("ddMMyyyyHHmmss");
                    string fileName = "ReporteMatriculas_" + actualDate + ".xlsx";

                    return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
                }
                
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(500, "Ocurrió un error al generar el archivo Excel: " + ex.Message);
            }
        }
    }
}
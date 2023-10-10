using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Sol.UI.Util
{
    public static class ApiEndpoints
    {
        private static string ApiBaseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];

        public static string GetAllStudentsEndpoint() => $"{ApiBaseUrl}/Student";
        public static string GetAllActivesStudentsEndpoint() => $"{ApiBaseUrl}/Student/GetActives";
        public static string GetReportEnrollmentEndpoint() => $"{ApiBaseUrl}/Enrollment/Report";
        public static string GetAllActiveSectionsEndpoint() => $"{ApiBaseUrl}/Section/GetActives";
        public static string GetAllCoursesEndpoint() => $"{ApiBaseUrl}/Course";
        public static string PostEnrollStudent() => $"{ApiBaseUrl}/Enrollment";

    }
}
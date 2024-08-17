using System;

namespace Company.Project.Web.Models
{
    public class ErrorViewModel
    {
        /// <summary>
        /// Implements Domain Logic by handling the data passed between the database and UI
        /// Model for Errors
        /// </summary>
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}

using Architecture.Generic.Infrastructure;
using System;
using System.Collections.Generic;

namespace Architecture.Generic.Models.ApiModel
{
    public class ApiResponse
    {
        public ApiResponse()
        {
            code = StatusCode.StatusCode0;
            responseData = new object();
            //errors = new List<ErrorList>();
        }

        public string code { get; set; }
        public bool isSuccess { get; set; }
        public string message { get; set; }
        public object responseData { get; set; }
        //public List<ErrorList> errors { get; set; }
    }

    public sealed class ApiResponse<T> : ApiResponse
    {
        public T data { get; set; }
    }

    public sealed class ApiResponseList<T> : ApiResponse
    {
        public List<T> data { get; set; }
    }

    public class ServiceResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }

    public class ErrorList
    {
        public string field { get; set; }
        public string errorCode { get; set; }
        public string message { get; set; }
    }

    public class LoginMessagemodel
    {
        public string DataKey { get; set; }
        public string DataMessage { get; set; }

    }

    public class FileUploadServiceResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public string ErrorCode { get; set; }
        public string Key { get; set; }
    }

    public class UploadedFileModel
    {
        public string FileOriginalName { get; set; }
        public string FilePath { set; get; }
        public string NewFileName { set; get; }
        public bool IsUploaded { get; set; }
    }

    public class UploadServiceResponse
    {
        public bool isSuccess { get; set; }
        public string fileName { set; get; }
        public string filePath { set; get; }
        public string errorMessage { get; set; }
    }
}
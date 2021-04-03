﻿using SigortamNet.Contracts.Enums;

namespace SigortamNet.Contracts.Results
{
    public class ServiceResult
    {
        public ServiceResult(Status status)
        {
            Status = status;
        }

        public Status Status { get; }
        public string Message { get; set; }
        public bool IsSucceed => Status == Status.Success;
        public bool IsFailed => !IsSucceed;
    }

    public class ServiceResult<T> : ServiceResult
    {
        public ServiceResult(Status status) : base(status)
        {
        }

        public T Object { get; set; }
    }
}

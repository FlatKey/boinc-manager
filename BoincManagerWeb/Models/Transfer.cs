﻿using BoincManager;
using BoincManager.Interfaces;
using BoincManager.Models;
using System.Collections.Generic;

namespace BoincManagerWeb.Models
{
    public class Transfer : ITransfer, IFilterable
    {
        public int HostId { get; }
        public string HostName { get; }
        public string Project { get; }
        public string FileName { get; }
        public double Progress { get; }
        public string FileSize { get; }
        public string TransferRate { get; }
        public string ElapsedTime { get; }
        public string TimeRemaining { get; }
        public string Status { get; }

        public Transfer(HostState hostState, BoincRpc.FileTransfer fileTransfer)
        {
            HostId = hostState.Id;
            HostName = hostState.Name;

            Project = fileTransfer.ProjectName;
            FileName = fileTransfer.Name;
            Progress = fileTransfer.NumberOfBytes > 0 ? fileTransfer.BytesTransferred / fileTransfer.NumberOfBytes : 0;
            FileSize = BoincManager.Utils.ConvertBytesToFileSize(fileTransfer.NumberOfBytes);
            TransferRate = fileTransfer.TransferActive ? $"{BoincManager.Utils.ConvertBytesToFileSize(fileTransfer.TransferSpeed)} /s" : string.Empty;
            ElapsedTime = BoincManager.Utils.ConvertDuration(fileTransfer.TimeSoFar);
            TimeRemaining = fileTransfer.TransferActive ? BoincManager.Utils.GetTimeRemaining(fileTransfer) : string.Empty;
            Status = Statuses.GetTransferStatus(fileTransfer);
        }

        public IEnumerable<string> GetContentsForFiltering()
        {
            yield return HostName;
            yield return Project;
            yield return FileName;
            yield return FileSize;
            yield return TransferRate;
            yield return ElapsedTime;
            yield return TimeRemaining;
            yield return Status;
        }
    }
}

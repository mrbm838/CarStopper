using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP010
{
    /// <summary>
    /// PLC类型
    /// </summary>
    public enum PLCType
    {
        汇川,
        欧姆龙,
        信捷
    }

    /// <summary>
    /// PLC数据类型
    /// </summary>
    public enum PLCData
    {
        Enum_Bool,
        Enum_Short,
        Enum_Int,
        Enum_Long,
        Enum_Double,
        Enum_Float,
        Enum_String
    }


    /// <summary>
    /// 工作步骤
    /// </summary>
    public enum WorkStep
    {
        GetStart,
        Start,
        WaitSignal,
        TriggerScan,
        ScanOK,
        ScanNG,
        GetSN,
        ReturnScanOK,
        ReturnScanNG,
        WaitReachSignal,
        SendCmd,
        GetPointData,
        StartCorrect,
        CorrectOK,
        ReturnCorrectOKSignal,
        WriteToMysql,
        UpdatePassStation,
        Completed
    }


    public enum AtlasType
    {
        OneByOne,
        Receive
    }


    public enum ListenStep
    {
        GetStart,
        Start,
        JudgeType,
        Listen,
        GetData,
        WriteToSql,
        Completed
    }

    public enum SocketType
    {
        Client,
        Serve
    }

    public enum ErrorType
    {
        错误,
        警告,
        危险,
        紧急停止
    }

    public enum EnumPosition
    {
        待命位 = 0,
        收料位
    }
}

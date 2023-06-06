using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Cowain_AutoMachine.Flow.IO_Cylinder_Motor;
using MotionBase;
using Cowain_AutoMachine.Flow.IO_Cylinder;
using OpenOffice_Connect;

namespace OP001.Motion
{
    public class MotionModule : Base
    {
        private AddMDBMachineData MDB;

        public MotionModule()
        {
            m_strMachinePath = Environment.CurrentDirectory + "\\Machine.mdb";
            clsMachinePoint.Path = m_strMachinePath;
            clsMotors clsMotor = new clsMotors(this, 0, m_strMachinePath, "", 2000);
            AddBase(ref clsMotor.m_NowAddress);
            clsCylinders clsCylinder = new clsCylinders(this, 0, m_strMachinePath, "", 2000);
            AddBase(ref clsCylinder.m_NowAddress);
            clsIO_Ports clsPort = new clsIO_Ports(this, 0, m_strMachinePath, "", 2000);
            AddBase(ref clsPort.m_NowAddress);
            StartInitial();

            ReadMachinePointsData();
            MotorsInitialize();
            CylindersInitialize();
            IOInitialize();
            RunnerInitialize();
        }

        private void ReadMachinePointsData()
        {
            MDB = new AddMDBMachineData(m_strMachinePath);
            MDB.ReadTables("MachineData");
            StaticParam.MachineAxesPoints.Clear();
            for (int i = 0; i < MDB.List_Msg.Count; i++)
            {
                string[] str = MDB.List_Msg[i].Split(',');
                clsMachinePoint point = new clsMachinePoint(str[2].Trim());
                if (!StaticParam.MachineAxesPoints.Keys.Contains(point.PointName) && point.Enable)
                {
                    StaticParam.MachineAxesPoints.Add(point.PointName, point);
                }
            }

            for (int j = 0; j < StaticParam.Points.Length; j++)
            {
                var posName = ((EnumPosition)j).ToString();
                if (StaticParam.MachineAxesPoints.Keys.Contains(posName))
                {
                    StaticParam.Points[j] = StaticParam.MachineAxesPoints[posName].Point;
                }
            }
        }

        private void MotorsInitialize()
        {
            StaticParam.AxisZ = clsMotors.MotorList["M01"];
            StaticParam.AxisR = clsMotors.MotorList["M02"];
        }

        private void CylindersInitialize()
        {
            StaticParam.ValveSta1 = clsCylinders.CylinderList["V01001"];
            StaticParam.ValveSta2 = clsCylinders.CylinderList["V01002"];
            StaticParam.ValveSta3 = clsCylinders.CylinderList["V01003"];
            StaticParam.ValveSta4 = clsCylinders.CylinderList["V01004"];
            StaticParam.ValveSta5 = clsCylinders.CylinderList["V01005"];
        }

        private void IOInitialize()
        {
            // Input
            StaticParam.InputPort0 = clsIO_Ports.IOList["X0100"];
            StaticParam.InputPort1 = clsIO_Ports.IOList["X0101"];
            StaticParam.InputPort2 = clsIO_Ports.IOList["X0102"];
            StaticParam.InputPort3 = clsIO_Ports.IOList["X0103"];
            StaticParam.InputPort4 = clsIO_Ports.IOList["X0104"];
            StaticParam.InputPort8 = clsIO_Ports.IOList["X0108"];
            StaticParam.InputPort9 = clsIO_Ports.IOList["X0109"];
            StaticParam.InputPort12 = clsIO_Ports.IOList["X0112"];
            StaticParam.InputPort13 = clsIO_Ports.IOList["X0113"];
            StaticParam.InputPort14 = clsIO_Ports.IOList["X0114"];
            StaticParam.InputPort15 = clsIO_Ports.IOList["X0115"];
            // Output
            StaticParam.OutputPort0 = clsIO_Ports.IOList["Y1100"];
            StaticParam.OutputPort1 = clsIO_Ports.IOList["Y1101"];
            StaticParam.OutputPort2 = clsIO_Ports.IOList["Y1102"];
            StaticParam.OutputPort3 = clsIO_Ports.IOList["Y1103"];
            StaticParam.OutputPort4 = clsIO_Ports.IOList["Y1104"];
            StaticParam.OutputPort5 = clsIO_Ports.IOList["Y1105"];
            StaticParam.OutputPort6 = clsIO_Ports.IOList["Y1106"];
            StaticParam.OutputPort8 = clsIO_Ports.IOList["Y1105"];
            StaticParam.OutputPort9 = clsIO_Ports.IOList["Y1106"];

            StaticParam.InputArray = (from port in clsIO_Ports.IOList where port.Key.Contains("X01") && port.Key.Contains("X") select port.Value).Cast<DrvIO>().ToArray();
            StaticParam.OutputArray = (from port in clsIO_Ports.IOList where port.Key.Contains("Y110") && port.Key.Contains("Y") select port.Value).Cast<DrvIO>().ToArray();

        }

        private void RunnerInitialize()
        {
            //// Valve
            //StaticParam.R_ValveSta1 = clsCylinders.CylinderList["V01001"];
            //StaticParam.R_ValveSta2 = clsCylinders.CylinderList["V01002"];
            //StaticParam.R_ValveSta3 = clsCylinders.CylinderList["V01003"];
            //StaticParam.R_ValveSta4 = clsCylinders.CylinderList["V01004"];
            //StaticParam.R_ValveSta5 = clsCylinders.CylinderList["V01005"];
            //// Input
            //StaticParam.R_InputPort1 = clsIO_Ports.IOList["X0100"];
            //StaticParam.R_InputPort2 = clsIO_Ports.IOList["X0100"];
            //StaticParam.R_InputPort3 = clsIO_Ports.IOList["X0100"];
            //StaticParam.R_InputPort4 = clsIO_Ports.IOList["X0100"];
            //StaticParam.R_InputPort5 = clsIO_Ports.IOList["X0100"];
            //// Output
            //StaticParam.R_OutputPort1 = clsIO_Ports.IOList["Y0100"];
            //StaticParam.R_OutputPort2 = clsIO_Ports.IOList["Y0100"];
            //StaticParam.R_OutputPort3 = clsIO_Ports.IOList["Y0100"];
            //StaticParam.R_OutputPort4 = clsIO_Ports.IOList["Y0100"];
            //StaticParam.R_OutputPort5 = clsIO_Ports.IOList["Y0100"];

            StaticParam.R_InputArray = (from port in clsIO_Ports.IOList where !port.Key.Contains("X01") && port.Key.Contains("X") select port.Value).Cast<DrvIO>().ToArray();
            StaticParam.R_OutputArray = (from port in clsIO_Ports.IOList where !port.Key.Contains("Y110") && port.Key.Contains("Y") select port.Value).Cast<DrvIO>().ToArray();
        }

        public enum enInitStep
        {
            StartLoading,
            載入Machine_Data,
            載入Work_Data,
            系統資料Init,
            系統Init完成,
            enMax,
        }

        public string GetDataBasePath() => m_strMachinePath;
    }
}

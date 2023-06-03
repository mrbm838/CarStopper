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

namespace OP010.Motion
{
    public class MotionModule : Base
    {
        private AddMDBMachineData MDB;

        public MotionModule()
        {
            m_strMachinePath = Environment.CurrentDirectory + "\\Machine.mdb";
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
            StaticParam.InputPort1 = clsIO_Ports.IOList["X0100"];
            StaticParam.InputPort2 = clsIO_Ports.IOList["X0100"];
            StaticParam.InputPort3 = clsIO_Ports.IOList["X0100"];
            StaticParam.InputPort4 = clsIO_Ports.IOList["X0100"];
            StaticParam.InputPort5 = clsIO_Ports.IOList["X0100"];
            // Output
            StaticParam.OutputPort1 = clsIO_Ports.IOList["Y1100"];
            StaticParam.OutputPort2 = clsIO_Ports.IOList["Y1100"];
            StaticParam.OutputPort3 = clsIO_Ports.IOList["Y1100"];
            StaticParam.OutputPort4 = clsIO_Ports.IOList["Y1100"];
            StaticParam.OutputPort5 = clsIO_Ports.IOList["Y1100"];
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
    }
}

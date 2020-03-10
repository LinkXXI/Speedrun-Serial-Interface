using System;
using System.Collections.Generic;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;

namespace Speedrun_Serial_Interface
{
    public class SerialPortInfo
    {
        public static List<SerialPortInfo> serialPorts = new List<SerialPortInfo>();

        public SerialPortInfo(ManagementObject property)
        {
            this.Availability = property.GetPropertyValue("Availability") as int? ?? 0;
            this.Caption = property.GetPropertyValue("Caption") as string ?? string.Empty;
            this.ClassGuid = property.GetPropertyValue("ClassGuid") as string ?? string.Empty;
            this.CompatibleID = property.GetPropertyValue("CompatibleID") as string[] ?? new string[] { };
            this.ConfigManagerErrorCode = property.GetPropertyValue("ConfigManagerErrorCode") as int? ?? 0;
            this.ConfigManagerUserConfig = property.GetPropertyValue("ConfigManagerUserConfig") as bool? ?? false;
            this.CreationClassName = property.GetPropertyValue("CreationClassName") as string ?? string.Empty;
            this.Description = property.GetPropertyValue("Description") as string ?? string.Empty;
            this.DeviceID = property.GetPropertyValue("DeviceID") as string ?? string.Empty;
            this.ErrorCleared = property.GetPropertyValue("ErrorCleared") as bool? ?? false;
            this.ErrorDescription = property.GetPropertyValue("ErrorDescription") as string ?? string.Empty;
            this.HardwareID = property.GetPropertyValue("HardwareID") as string[] ?? new string[] { };
            this.InstallDate = property.GetPropertyValue("InstallDate") as DateTime? ?? DateTime.MinValue;
            this.LastErrorCode = property.GetPropertyValue("LastErrorCode") as int? ?? 0;
            this.Manufacturer = property.GetPropertyValue("Manufacturer") as string ?? string.Empty;
            this.Name = property.GetPropertyValue("Name") as string ?? string.Empty;
            this.PNPClass = property.GetPropertyValue("PNPClass") as string ?? string.Empty;
            this.PNPDeviceID = property.GetPropertyValue("PNPDeviceID") as string ?? string.Empty;
            this.PowerManagementCapabilities = property.GetPropertyValue("PowerManagementCapabilities") as int[] ?? new int[] { };
            this.PowerManagementSupported = property.GetPropertyValue("PowerManagementSupported") as bool? ?? false;
            this.Present = property.GetPropertyValue("Present") as bool? ?? false;
            this.Service = property.GetPropertyValue("Service") as string ?? string.Empty;
            this.Status = property.GetPropertyValue("Status") as string ?? string.Empty;
            this.StatusInfo = property.GetPropertyValue("StatusInfo") as int? ?? 0;
            this.SystemCreationClassName = property.GetPropertyValue("SystemCreationClassName") as string ?? string.Empty;
            this.SystemName = property.GetPropertyValue("SystemName") as string ?? string.Empty;

            Regex rgx = new Regex(@"(?<=\().+?(?=\))");
            this.COMPortName = rgx.Match(this.Caption).Groups[0].Value;

            rgx = null;
        }

        public int Availability;
        public string Caption;
        public string ClassGuid;
        public string[] CompatibleID;
        public int ConfigManagerErrorCode;
        public bool ConfigManagerUserConfig;
        public string CreationClassName;
        public string Description;
        public string DeviceID;
        public bool ErrorCleared;
        public string ErrorDescription;
        public string[] HardwareID;
        public DateTime InstallDate;
        public int LastErrorCode;
        public string Manufacturer;
        public string Name;
        public string PNPClass;
        public string PNPDeviceID;
        public int[] PowerManagementCapabilities;
        public bool PowerManagementSupported;
        public bool Present;
        public string Service;
        public string Status;
        public int StatusInfo;
        public string SystemCreationClassName;
        public string SystemName;
        public string COMPortName;

        public static void GetPortInformation()
        {
            ManagementClass processClass = new ManagementClass("Win32_PnPEntity");
            ManagementObjectCollection Ports = processClass.GetInstances();

            foreach (ManagementObject property in Ports)
            {
                var name = property.GetPropertyValue("Name");
                if (name != null && name.ToString().Contains("COM"))
                {
                    var portInfo = new SerialPortInfo(property);
                    serialPorts.Add(portInfo);
                    //Thats all information i got from port.
                    //Do whatever you want with this information
                }
            }
        }
    }
}

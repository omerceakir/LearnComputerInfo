using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LearnComputerInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Learn Computer Info - C3";
            //Console.SetWindowSize(90, 50); //Boyut Ayari
            Brace("   IG: @omerceakir                                            Version 0.0.1", ConsoleColor.Green);
            MyLogo();                                                                        
            Brace("PC Controller Running...                             " + DateTime.Now.ToString(CultureInfo.CreateSpecificCulture("tr-TR")), ConsoleColor.Green);
            Console.WriteLine();

            Brace("Computer  Name                   : " + Dns.GetHostName(), ConsoleColor.DarkYellow);
            Brace("Processor Info", ConsoleColor.Green);
            ProcessorInfo();

            Brace("Random Access Memory Info", ConsoleColor.Green);
            RAMInfo();

            Brace("Operating System Info", ConsoleColor.Green);
            OSInfo();

            Brace("Display Video Controller Info", ConsoleColor.Green);
            DisplayVideoControllerInfo();

            Brace("Display Controller Configuration Info", ConsoleColor.Green);
            DisplayControllerConfigurationInfo();

            Brace("Display Configuration Info", ConsoleColor.Green);
            DisplayConfigurationInfo();

            Brace("Storage Info", ConsoleColor.Green);
            StorageInfo();

            Brace("Sound card (audio devices) Info", ConsoleColor.Green);
            SoundCardInfo();

            Brace("System Security Info", ConsoleColor.Green);
            SystemSecurityInfo();

            Brace("LOCAL-IP List Info", ConsoleColor.Green);
            LocalIPListInfo();

            Brace("Printer Info", ConsoleColor.Green);
            PrinterInfo();

            Brace("PC Controller Stopping...                             " + DateTime.Now.ToString(CultureInfo.CreateSpecificCulture("tr-TR")), ConsoleColor.Green);
            Console.WriteLine();

            Console.SetCursorPosition(1, 1);

            Console.ReadLine();
        }
        private static void MyLogo()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n");
            Console.WriteLine(" 00000000000000000000000000000&        Program Hicbir Veri Kaydetmez.");
            Console.WriteLine(" 00000000000000000000000000000&        Veriler Anlik Olarak Gosterir.");
            Console.WriteLine(" 00000000000000000000000000000&        Kapatildiginda Tum Veriler Yok Olur.");
            Console.WriteLine(" 00000000000000000000000000000&        Ucretsiz Bir Programdır.");
            Console.WriteLine(" 000000                         ");
            Console.WriteLine(" 000000    ]000000000000000000f ");
            Console.WriteLine(" 000000    ]000000000000000000f ");
            Console.WriteLine(" 000000     ``````````````~000f ");
            Console.WriteLine(" 000000                    000f ");
            Console.WriteLine(" 000000          0000000000000f ");
            Console.WriteLine(" 000000          0000000000000f ");
            Console.WriteLine(" 000000          ~~~~~~~~~~000f ");
            Console.WriteLine(" 000000                    000f ");
            Console.WriteLine(" 000000    ]ggggggggggggggN000f ");
            Console.WriteLine(" 000000    ]000000000000000000f ");
            Console.WriteLine(" 000000     ~~~~~~~~~~~~~~~~~~  ");
            Console.WriteLine(" 000000                         ");
            Console.WriteLine(" 000000pgggggggggggggggggggggg  ");
            Console.WriteLine(" 00000000000000000000000000000f ");
            Console.WriteLine(" 00000000000000000000000000000f ");
            Console.WriteLine(" 00000000000000000000000000000f ");
            Console.WriteLine(" ^````^````^````^````^````^```                       ../Omer CAKIR/\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void H3(ConsoleColor colors = ConsoleColor.White)
        {
            switch (colors)
            {
                case ConsoleColor.Blue: Console.ForegroundColor = ConsoleColor.Blue; break;
                case ConsoleColor.Red: Console.ForegroundColor = ConsoleColor.Red; break;
                case ConsoleColor.DarkRed: Console.ForegroundColor = ConsoleColor.DarkRed; break;
                case ConsoleColor.Green: Console.ForegroundColor = ConsoleColor.Green; break;
                case ConsoleColor.Gray: Console.ForegroundColor = ConsoleColor.Gray; break;
                case ConsoleColor.DarkGray: Console.ForegroundColor = ConsoleColor.DarkGray; break;
                case ConsoleColor.Yellow: Console.ForegroundColor = ConsoleColor.Yellow; break;
                case ConsoleColor.DarkYellow: Console.ForegroundColor = ConsoleColor.DarkYellow; break;
                default: Console.ForegroundColor = ConsoleColor.White; break;
            }

        }
        private static void Brace(string Title, ConsoleColor ColorH3 = ConsoleColor.White)
        {
            H3(ColorH3);
            Console.WriteLine("\n" + Title);
            Console.WriteLine("---------------------------------------------------------------------------");
            H3();
        }
        public static void CPUTemperature()
        {
            Double temperature = 0;
            String instanceName = "";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"root\WMI", "SELECT * FROM MSAcpi_ThermalZoneTemperature");
            foreach (ManagementObject obj in searcher.Get())
            {
                temperature = Convert.ToDouble(obj["CurrentTemperature"].ToString());
                temperature = (temperature - 2732) / 10.0;
                instanceName = obj["InstanceName"].ToString();
            }
            Console.WriteLine("Temperature                      : " + temperature);
            H3(ConsoleColor.Yellow);
            Console.WriteLine("InstanceName                     : " + instanceName + "\n");
        } //Hata Olusturabiliyor!
        private static void ProcessorInfo()
        {
            ManagementObjectSearcher cpu = new ManagementObjectSearcher("Select * From Win32_Processor");
            foreach (ManagementObject cpuInfo in cpu.Get())
            {
                H3(ConsoleColor.DarkGray);
                Console.WriteLine("Processor ID                     : " + cpuInfo["ProcessorId"].ToString());
                H3(ConsoleColor.DarkYellow);
                Console.WriteLine("Processor Name                   : " + cpuInfo["Name"].ToString());
                H3(ConsoleColor.Yellow);
                Console.WriteLine("Processor Core Count             : " + cpuInfo["NumberOfLogicalProcessors"].ToString());
                Console.WriteLine("L2 Cache  Size                   : " + cpuInfo["L2CacheSize"]);
                H3(ConsoleColor.DarkGray);
                Console.WriteLine("L2 Cache  Speed                  : " + cpuInfo["L2CacheSpeed"]);
                Console.WriteLine("L3 Cache  Size                   : " + cpuInfo["L3CacheSize"]);
                Console.WriteLine("L3 Cache  Speed                  : " + cpuInfo["L3CacheSpeed"]);
                Console.WriteLine("DeviceID                         : " + cpuInfo["DeviceID"]);
                Console.WriteLine("Version                          : " + cpuInfo["Version"]);
                Console.WriteLine("DeviceID                         : " + cpuInfo["DeviceID"]);
                H3(ConsoleColor.DarkYellow);
                Console.WriteLine("Manufacturer                     : " + cpuInfo["Manufacturer"]);
                H3(ConsoleColor.Yellow);
                Console.WriteLine("CurrentClockSpeed                : " + cpuInfo["CurrentClockSpeed"]);
                Console.WriteLine("Caption                          : " + cpuInfo["Caption"]);
                H3(ConsoleColor.DarkGray);
                Console.WriteLine("NumberOfCores                    : " + cpuInfo["NumberOfCores"]);
                Console.WriteLine("NumberOfEnabledCore              : " + cpuInfo["NumberOfEnabledCore"]);
                Console.WriteLine("Architecture                     : " + cpuInfo["Architecture"]);
                Console.WriteLine("Family                           : " + cpuInfo["Family"]);
                Console.WriteLine("ProcessorType                    : " + cpuInfo["ProcessorType"]);
                Console.WriteLine("Characteristics                  : " + cpuInfo["Characteristics"]);
                H3(ConsoleColor.DarkYellow);
                Console.WriteLine("AddressWidth                     : " + cpuInfo["AddressWidth"]+"\n");
                //CPUTemperature();
                H3(ConsoleColor.DarkGray);
            }
        }
        private static void RAMInfo()
        {
            ManagementObjectSearcher physical = new ManagementObjectSearcher("Select *From Win32_PhysicalMemory");
            foreach (ManagementObject physicalInfo in physical.Get())
            {
                int type = 0;
                H3(ConsoleColor.DarkYellow);
                Console.WriteLine("Manufacturer                     : " + physicalInfo["Manufacturer"].ToString());
                double capacityBytes = (Convert.ToDouble(physicalInfo["Capacity"]));
                double capacityGB = capacityBytes / 1073741824;
                double capacity = Math.Ceiling(capacityGB);
                H3(ConsoleColor.Yellow);
                Console.WriteLine("Capacity GB                      : " + capacity.ToString() + " GB");
                H3(ConsoleColor.DarkGray);
                Console.WriteLine("Capacity Bytes                   : " + physicalInfo["Capacity"].ToString());
                Console.WriteLine("Tag                              : " + physicalInfo["Tag"].ToString());
                Console.WriteLine("DeviceLocator                    : " + physicalInfo["DeviceLocator"].ToString());
                H3(ConsoleColor.DarkYellow);
                Console.WriteLine("Speed                            : " + physicalInfo["Speed"].ToString());
                type = Int32.Parse(physicalInfo.GetPropertyValue("MemoryType").ToString());
                switch (type)
                {
                    case 20:
                        Console.WriteLine("MemoryType                       : " + "DDR");
                        break;
                    case 21:
                        Console.WriteLine("MemoryType                       : " + "DDR-2");
                        break;
                    case 17:
                        Console.WriteLine("MemoryType                       : " + "SDRAM");
                        break;
                    default:
                        if (type == 0 || type > 22)
                            Console.WriteLine("MemoryType                       : " + "DDR-3");
                        else
                            Console.WriteLine("MemoryType                       : " + "Unknown");
                        break;
                }
                H3(ConsoleColor.Yellow);
                Console.WriteLine("Configured Clock Speed           : " + physicalInfo["ConfiguredClockSpeed"].ToString() + "\n");
            }

            ManagementObjectSearcher ram = new ManagementObjectSearcher("Select *From Win32_ComputerSystem");
            H3(ConsoleColor.Red);
            foreach (ManagementObject ramInfo in ram.Get())
            {
                double Ram_Bytes = (Convert.ToDouble(ramInfo["TotalPhysicalMemory"]));
                double ramgb = Ram_Bytes / 1073741824;
                double ramSize = Math.Ceiling(ramgb);
                Console.WriteLine("TOTAL RAM                        : " + ramSize.ToString() + " GB\n");
            }
        }
        private static void OSInfo()
        {
            ManagementObjectSearcher os = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
            foreach (ManagementObject obj in os.Get())
            {
                H3(ConsoleColor.Red);
                Console.WriteLine("Caption                          : " + obj["Caption"]);
                H3(ConsoleColor.DarkGray);
                Console.WriteLine("WindowsDirectory                 : " + obj["WindowsDirectory"]);
                Console.WriteLine("ProductType                      : " + obj["ProductType"]);
                H3(ConsoleColor.Red);
                Console.WriteLine("SerialNumber                     : " + obj["SerialNumber"]);
                H3(ConsoleColor.DarkGray);
                Console.WriteLine("SystemDirectory                  : " + obj["SystemDirectory"]);
                Console.WriteLine("CountryCode                      : " + obj["CountryCode"]);
                Console.WriteLine("CurrentTimeZone                  : " + obj["CurrentTimeZone"]);
                Console.WriteLine("EncryptionLevel                  : " + obj["EncryptionLevel"]);
                Console.WriteLine("OSType                           : " + obj["OSType"]);
                H3(ConsoleColor.Yellow);
                Console.WriteLine("Version                          : " + obj["Version"]);
            }
            H3(ConsoleColor.DarkYellow);
            bool is64bit = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"));
            if (is64bit)
                Console.WriteLine("System Type                      : " + "x64");
            else
                Console.WriteLine("System Type                      : " + "x86");
            H3(ConsoleColor.DarkGray);
            CultureInfo ci = CultureInfo.InstalledUICulture;
            Console.WriteLine("Installed UI Language Info       : " + ci.Name);
            Console.WriteLine("Display Name                     : " + ci.DisplayName);
            Console.WriteLine("English Name                     : " + ci.EnglishName);
            Console.WriteLine("Compare Info                     : " + ci.CompareInfo);
            Console.WriteLine("Native Name                      : " + ci.NativeName);
            Console.WriteLine("Text Info                        : " + ci.TextInfo);
            Console.WriteLine("2-letter ISO Name                : " + ci.TwoLetterISOLanguageName);
            Console.WriteLine("3-letter ISO Name                : " + ci.ThreeLetterISOLanguageName);
            Console.WriteLine("3-letter Win32 API Name          : " + ci.ThreeLetterWindowsLanguageName);
            Console.WriteLine("Installed Language Info          : " + ci.Name); ci = CultureInfo.CurrentUICulture;
            Console.WriteLine("Current UI Language Info         : " + ci.Name); ci = CultureInfo.CurrentCulture;
            Console.WriteLine("Current Language Info            : " + ci.Name+"\n");
        }
        private static void DisplayVideoControllerInfo()
        {
            ManagementObjectSearcher display = new ManagementObjectSearcher("Select *From Win32_VideoController");
            foreach (ManagementObject displayInfo in display.Get())
            {
                H3(ConsoleColor.DarkYellow);
                Console.WriteLine("Caption                          : " + displayInfo["Caption"]);
                H3(ConsoleColor.Yellow);
                Console.WriteLine("Description                      : " + displayInfo["Description"]);
                H3(ConsoleColor.DarkGray);
                Console.WriteLine("InstallDate                      : " + displayInfo["InstallDate"]);
                Console.WriteLine("Name                             : " + displayInfo["Name"]);
                Console.WriteLine("Status                           : " + displayInfo["Status"]);
                Console.WriteLine("Availability                     : " + displayInfo["Availability"]);
                Console.WriteLine("CreationClassName                : " + displayInfo["CreationClassName"]);
                Console.WriteLine("DeviceID                         : " + displayInfo["DeviceID"]);
                Console.WriteLine("PNPDeviceID                      : " + displayInfo["PNPDeviceID"]);
                Console.WriteLine("SystemCreationClassName          : " + displayInfo["SystemCreationClassName"]);
                H3(ConsoleColor.DarkYellow);
                Console.WriteLine("SystemName                       : " + displayInfo["SystemName"]);
                Console.WriteLine("CurrentBitsPerPixel              : " + displayInfo["CurrentBitsPerPixel"]);
                Console.WriteLine("CurrentHorizontalResolution      : " + displayInfo["CurrentHorizontalResolution"]);
                Console.WriteLine("CurrentVerticalResolution        : " + displayInfo["CurrentVerticalResolution"]);
                Console.WriteLine("CurrentNumberOfColors            : " + displayInfo["CurrentNumberOfColors"]);
                Console.WriteLine("CurrentRefreshRate               : " + displayInfo["CurrentRefreshRate"]);
                H3(ConsoleColor.DarkGray);
                Console.WriteLine("CurrentScanMode                  : " + displayInfo["CurrentScanMode"]);
                H3(ConsoleColor.Yellow);
                Console.WriteLine("MaxRefreshRate                   : " + displayInfo["MaxRefreshRate"]);
                Console.WriteLine("MinRefreshRate                   : " + displayInfo["MinRefreshRate"]);
                H3(ConsoleColor.DarkGray);
                Console.WriteLine("NumberOfVideoPages               : " + displayInfo["NumberOfVideoPages"]);
                Console.WriteLine("VideoMemoryType                  : " + displayInfo["VideoMemoryType"]);
                H3(ConsoleColor.DarkYellow);
                Console.WriteLine("VideoProcessor                   : " + displayInfo["VideoProcessor"]);
                H3(ConsoleColor.DarkGray);
                Console.WriteLine("NumberOfColorPlanes              : " + displayInfo["NumberOfColorPlanes"]);
                Console.WriteLine("VideoArchitecture                : " + displayInfo["VideoArchitecture"]);
                Console.WriteLine("VideoMode                        : " + displayInfo["VideoMode"]);
                Console.WriteLine("AdapterCompatibility             : " + displayInfo["AdapterCompatibility"]);
                Console.WriteLine("AdapterDACType                   : " + displayInfo["AdapterDACType"]);
                H3(ConsoleColor.Red);
                Console.WriteLine("AdapterRAM GB                    : " + SizeSuffix((long)Convert.ToDouble(displayInfo["AdapterRAM"])));
                H3(ConsoleColor.DarkGray);
                Console.WriteLine("AdapterRAM                       : " + displayInfo["AdapterRAM"]); //islem görecek! GB olacak
                Console.WriteLine("DriverDate                       : " + displayInfo["DriverDate"]);
                Console.WriteLine("DriverVersion                    : " + displayInfo["DriverVersion"]);
                Console.WriteLine("InfFilename                      : " + displayInfo["InfFilename"]);
                Console.WriteLine("InfSection                       : " + displayInfo["InfSection"]);
                Console.WriteLine("InstalledDisplayDrivers          : " + displayInfo["InstalledDisplayDrivers"]);
                H3(ConsoleColor.DarkYellow);
                Console.WriteLine("VideoModeDescription             : " + displayInfo["VideoModeDescription"] + "\n");
            }
        }
        private static void DisplayControllerConfigurationInfo()
        {
            ManagementObjectSearcher display2 = new ManagementObjectSearcher("Select *From Win32_DisplayControllerConfiguration");
            foreach (ManagementObject displayInfo2 in display2.Get())
            {
                H3(ConsoleColor.DarkYellow);
                Console.WriteLine("Caption                          : " + displayInfo2["Caption"]);
                H3(ConsoleColor.Yellow);
                Console.WriteLine("Description                      : " + displayInfo2["Description"]);
                Console.WriteLine("SettingID                        : " + displayInfo2["SettingID"]);
                H3(ConsoleColor.DarkGray);
                Console.WriteLine("BitsPerPixel                     : " + displayInfo2["BitsPerPixel"]);
                Console.WriteLine("ColorPlanes                      : " + displayInfo2["ColorPlanes"]);
                Console.WriteLine("DeviceEntriesInAColorTable       : " + displayInfo2["DeviceEntriesInAColorTable"]);
                Console.WriteLine("DeviceSpecificPens               : " + displayInfo2["DeviceSpecificPens"]);
                H3(ConsoleColor.DarkYellow);
                Console.WriteLine("HorizontalResolution             : " + displayInfo2["HorizontalResolution"]);
                Console.WriteLine("Name                             : " + displayInfo2["Name"]);
                Console.WriteLine("RefreshRate                      : " + displayInfo2["RefreshRate"]);
                Console.WriteLine("VerticalResolution               : " + displayInfo2["VerticalResolution"]);
                Console.WriteLine("VideoMode                        : " + displayInfo2["VideoMode"]+"\n");
            }
        }
        private static void DisplayConfigurationInfo()
        {
            ManagementObjectSearcher display3 = new ManagementObjectSearcher("Select *From Win32_DisplayConfiguration");
            foreach (ManagementObject displayInfo3 in display3.Get())
            {
                H3(ConsoleColor.DarkYellow);
                Console.WriteLine("Caption                          : " + displayInfo3["Caption"]);
                H3(ConsoleColor.Yellow);
                Console.WriteLine("Description                      : " + displayInfo3["Description"]);
                Console.WriteLine("SettingID                        : " + displayInfo3["SettingID"]);
                H3(ConsoleColor.DarkGray);
                Console.WriteLine("BitsPerPel                       : " + displayInfo3["BitsPerPel"]);
                Console.WriteLine("DeviceName                       : " + displayInfo3["DeviceName"]);
                Console.WriteLine("DisplayFlags                     : " + displayInfo3["DisplayFlags"]);
                Console.WriteLine("DisplayFrequency                 : " + displayInfo3["DisplayFrequency"]);
                Console.WriteLine("LogPixels                        : " + displayInfo3["LogPixels"]);
                H3(ConsoleColor.DarkYellow);
                Console.WriteLine("PelsHeight                       : " + displayInfo3["PelsHeight"]);
                Console.WriteLine("PelsWidth                        : " + displayInfo3["PelsWidth"]);
                H3(ConsoleColor.DarkGray);
                Console.WriteLine("SpecificationVersion             : " + displayInfo3["SpecificationVersion"]+"\n");
            }
        }

        static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        static string SizeSuffix(Int64 value)
        {
            if (value < 0) { return "-" + SizeSuffix(-value); }
            if (value == 0) { return "0.0 bytes"; }

            int mag = (int)Math.Log(value, 1024);
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            return string.Format("{0:n1} {1}", adjustedSize, SizeSuffixes[mag]);
        } //Ekran Kartinin Boyutunu Bulma 
        private static void StorageInfo()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                H3(ConsoleColor.Red);
                Console.WriteLine(" Drive {0}", d.Name);
                Console.WriteLine(" '''''''''''''''''''''''''''''''''");
                H3(ConsoleColor.DarkGray);
                Console.WriteLine("  Drive Type                     : {0}", d.DriveType);
                if (d.IsReady == true)
                {
                    H3(ConsoleColor.DarkYellow);
                    Console.WriteLine("  Volume Label                   : {0}", d.VolumeLabel);
                    Console.WriteLine("  File System                    : {0}", d.DriveFormat);
                    H3(ConsoleColor.Yellow);
                    Console.WriteLine("  Available Space To CurrentUser : {0, 15}", SizeSuffix(d.AvailableFreeSpace));
                    Console.WriteLine("  Total Available Space          : {0, 15}", SizeSuffix(d.TotalFreeSpace));
                    Console.WriteLine("  Total Size Of Drive            : {0, 15} ", SizeSuffix(d.TotalSize));
                    H3(ConsoleColor.DarkGray);
                    Console.WriteLine("  Root Directory                 : {0, 12}", d.RootDirectory + "\n");
                }
            }
        }
        private static void SoundCardInfo()
        {
            ManagementObjectSearcher audio = new ManagementObjectSearcher("select * from Win32_SoundDevice");
            foreach (ManagementObject obj in audio.Get())
            {
                H3(ConsoleColor.DarkYellow);
                Console.WriteLine("Name                             : " + obj["Name"]);
                H3(ConsoleColor.Yellow);
                Console.WriteLine("ProductName                      : " + obj["ProductName"]);
                H3(ConsoleColor.DarkGray);
                Console.WriteLine("Availability                     : " + obj["Availability"]);
                Console.WriteLine("DeviceID                         : " + obj["DeviceID"]);
                Console.WriteLine("PowerManagementSupported         : " + obj["PowerManagementSupported"]);
                Console.WriteLine("Status                           : " + obj["Status"]);
                Console.WriteLine("StatusInfo                       : " + obj["StatusInfo"] + "\n");
            }
        }
        private static void SystemSecurityInfo()
        {
            ManagementObjectSearcher security = new ManagementObjectSearcher(@"root\SecurityCenter2", "SELECT * FROM AntiVirusProduct");
            foreach (ManagementObject securityInfo in security.Get())
            {
                H3(ConsoleColor.DarkYellow);
                Console.WriteLine("DisplayName                      : " + securityInfo["displayName"]);
                H3(ConsoleColor.DarkGray);
                Console.WriteLine("InstanceGuid                     : " + securityInfo["instanceGuid"]);
                Console.WriteLine("PatchToSignedProductExe          : " + securityInfo["pathToSignedProductExe"]);
                H3(ConsoleColor.DarkYellow);
                Console.WriteLine("ProductState                     : " + securityInfo["productState"] + "\n");
            }
        }
        private static void LocalIPListInfo()
        {
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface network in networkInterfaces)
            {
                IPInterfaceProperties properties = network.GetIPProperties();
                foreach (IPAddressInformation address in properties.UnicastAddresses)
                {
                    if (address.Address.AddressFamily != AddressFamily.InterNetwork)
                        continue;
                    if (IPAddress.IsLoopback(address.Address))
                        continue;
                    H3(ConsoleColor.DarkYellow);
                    Console.WriteLine("NetworkName                      : " + network.Name);
                    H3(ConsoleColor.Yellow);
                    Console.WriteLine("NetworkDescription               : " + network.Description);
                    Console.WriteLine("NetworkIP                        : " + address.Address.ToString());
                    H3(ConsoleColor.DarkGray);
                    Console.WriteLine("NetworkID                        : " + network.Id.ToString());
                    H3(ConsoleColor.Red);
                    Console.WriteLine("MACAddress                       : " + network.GetPhysicalAddress().ToString() + "\n");
                }
            }
        }
        private static void PrinterInfo()
        {
            ManagementObjectSearcher printer = new ManagementObjectSearcher("select * from Win32_Printer");
            foreach (ManagementObject obj in printer.Get())
            {
                H3(ConsoleColor.DarkYellow);
                Console.WriteLine("Name                             : " + obj["Name"]);
                H3(ConsoleColor.DarkGray);
                Console.WriteLine("Network                          : " + obj["Network"]);
                Console.WriteLine("Availability                     : " + obj["Availability"]);
                Console.WriteLine("Is default printer               : " + obj["Default"]);
                Console.WriteLine("DeviceID                         : " + obj["DeviceID"]);
                H3(ConsoleColor.Yellow);
                Console.WriteLine("Status                           : " + obj["Status"] + "\n");
            }
        }
    }
}

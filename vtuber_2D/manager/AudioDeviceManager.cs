using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.CoreAudioApi;
using System.Collections.ObjectModel;

namespace vtuber_2D.manager
{
    public class AudioDeviceManager
    {

        public ObservableCollection<string> GetAudioDevices()
        {
            ObservableCollection<string> devices = new ObservableCollection<string>();
            var enumerator = new MMDeviceEnumerator();
            var devicesCollection = enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);

            foreach ( var device in devicesCollection)
            {
                devices.Add(device.FriendlyName);
            }

            return devices;
        }
    }
}

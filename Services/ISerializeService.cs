using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ISerializeService
    {
        string SerializeFullGuestList(string path);

        string SerializeAttendingGuestList(string path);

        void DeserializeFullGuestList(string path);
    }
}

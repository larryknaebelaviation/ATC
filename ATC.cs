using System;
using System.Collections.Generic;
using flightmanagementcomputer;
using spatial;
using aircraft;

namespace airtrafficcontrol
{
    public class ATC
    {
        string id;
        List<Aircraft> aircraftList = new List<Aircraft>();
        //List<string> trackList = new List<string>();
        Dictionary<int,Aircraft> aircraftDict = new Dictionary<int,Aircraft> ();
        public ATC(string id)
        {
            this.id = id;
        }

        public void squawk(Aircraft ac)
        {
            aircraftList.Add(ac);
            aircraftDict.Add(ac.getId(), ac);
            //bbdict.Add(bb.getName(), bb);
            //trackList.Add(bb.getName());
            //aircraftList.
            // turns on event handling for specific aircraft
            ac.getFMC().getBlackBox().RaiseChangeEvent += Bb_RaiseChangeEvent;
        }

        private void Bb_RaiseChangeEvent(object sender, ChangeEvent e)
        {
            BlackBox tbb = (BlackBox)sender;
            
            Console.WriteLine(tbb.getName() + " " + e.ToString());
        }

        public List<Aircraft> whoTracking()
        {
            return aircraftList;
        }
       
        public Position getPosition(int aircraftId)
        {
            Aircraft ac;
            aircraftDict.TryGetValue(aircraftId, out ac);
            return ac.getCurrentPosition();
        }
    }
}

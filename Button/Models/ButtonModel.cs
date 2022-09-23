using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Button.Models
{
    public class ButtonModel
    {
        public ButtonModel(bool state, bool flagged)
        {
            State = state;
            Flagged = flagged;
        }

        public bool State { get; set; }
        public bool Flagged { get; set; }


    }
}
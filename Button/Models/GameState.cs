using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Button.Models
{
    public class GameState
    {
        public GameState(int id, string jSONString)
        {
            Id = id;
            JSONString = jSONString;
        }

        public int Id { get; set; }
        public string JSONString { get; set; }
        public GameState()
        {
            Id = 1;
            JSONString = "{}";
        }
    }
}
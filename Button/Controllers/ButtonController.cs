using Button.Models;
using Button.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Button.Controllers
{
    public class ButtonController : Controller
    {

        static List<ButtonModel> buttons = new List<ButtonModel>();
        Random rnd = new Random();
        public ButtonController()
        {
            if (buttons.Count == 0)
            {
                for (int i = 0; i < 25; i++)
                {
                    if (rnd.Next(10) < 5)
                    {
                        buttons.Add(new ButtonModel(false, false));
                    }
                    else
                    {
                        buttons.Add(new ButtonModel(true, false));
                    }
                }
            }
        }
        public ActionResult Index()
        {
            return View("Index",buttons);
        }
        public ActionResult OnSave()
        {
            GamesDAO gamesDAO = new GamesDAO();
            GameObject gameObject = new GameObject(1, JsonConvert.SerializeObject(buttons));// convert the list "buttons" into a Json string
            bool success = gamesDAO.SaveGame(gameObject);
            Tuple<bool, string> resultsTuple = new Tuple<bool, string>(success, JsonConvert.SerializeObject(buttons));
            return View("Results", resultsTuple);
        }
        public ActionResult OnLoad()
        {
            GamesDAO gamesDAO = new GamesDAO();
            GameObject gameObject = gamesDAO.LoadGame();
            buttons = JsonConvert.DeserializeObject<List<ButtonModel>>(gameObject.JSONstring);
            

            Tuple<bool, string> resultsTuple = new Tuple<bool, string>(true, JsonConvert.SerializeObject(buttons));
            return View("Results", resultsTuple);
        }
        public ActionResult HandleButtonClick(string mine)  
        {
            int number = int.Parse(mine);
            if (!buttons[number].Flagged)
            {
                buttons[number].State = !buttons[number].State; 
            }

            return View("Index", buttons);
        }
        public ActionResult OnRightButtonClick(string mine)
        {
            int mineNumber = Int32.Parse(mine);
            buttons[mineNumber].Flagged = !buttons[mineNumber].Flagged;
            return View("Index", buttons);
        }
    }
}
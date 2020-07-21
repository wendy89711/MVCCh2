using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using prjToDo.Models;
namespace prjToDo.Controllers
{
    public class HomeController : Controller
    {
        dbToDoEntities db = new dbToDoEntities();

        // GET: Home
        public ActionResult Index()
        {
            //將tToDo資料表內的紀錄依fDate欄位進行(遞減)排序並(轉成串列)再將結果(指定todos(變數)
            var todos = db.tToDo.OrderByDescending(m => m.fDate).ToList();
            //將(todos待辦事項)的所有紀錄傳到Index.cshtml的View檢視畫面
            return View(todos);
        }
    }
}
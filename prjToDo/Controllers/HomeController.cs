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

        public ActionResult Create()
        {
            return View();
        }
        
        //在Create.cshtml的檢視頁面按下submit會執行的方法
        [HttpPost]
        public ActionResult Create(string fTitle, string fImage, DateTime fDate)
        {
            tToDo todo = new tToDo();
            todo.fTitle = fTitle;
            todo.fImage = fImage;
            todo.fDate = fDate;
            db.tToDo.Add(todo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
        //網址傳入id參數
        public ActionResult Delete(int id)
        {
            var todo = db.tToDo.Where(m => m.fId == id).FirstOrDefault();
            //按下Delete連結到Home/Delete並傳入URL的id參數，id參數值為該筆待辦事項的編號，接著會刪除該筆資料
            db.tToDo.Remove(todo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var todo = db.tToDo.Where(m => m.fId == id).FirstOrDefault();
            return View(todo);
        }

        [HttpPost]
        public ActionResult Edit(int fId, string fTitle, string fImage, DateTime fDate)
        {
            //依fId取得要修改的todo項目
            var todo = db.tToDo.Where(m => m.fId == fId).FirstOrDefault();
            todo.fTitle = fTitle;
            todo.fImage = fImage;
            todo.fDate = fDate;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
using Framework.IoC.ServiceLocator;
using Framework.Mapper;
using StudentSystem.BLL.Interface;
using StudentSystem.Client.Model;
using StudentSystem.MVCWebClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentSystem.MVCWebClient.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/

        public ActionResult Index()
        {
            UIAdapter.Adapter adapter = new UIAdapter.Adapter();
            var instance = Locator.GetInstance<IStudentLogic>();
            var result = instance.GetStudents();

            List<ResultList> resultList = new List<ResultList>();

            foreach (StudentSystem.BLL.Model.Student student in result)
            {
                resultList.Add(Mapper.Map<ResultList>(student));
            }
            return View(resultList);
        }

        public ActionResult Profile(int id)
        {
            
            var instance = Locator.GetInstance<IStudentLogic>();
            var result = instance.GetStudent(id);

            ResultList resultListItem = new ResultList();

            resultListItem = Mapper.Map<ResultList>(result);

            resultListItem.Courses = new List<Course>();

            List<ResultList> resultList = new List<ResultList>();

            foreach (StudentSystem.BLL.Model.Course course in result.recCourses)
            {
                resultListItem.Courses.Add(Mapper.Map<Course>(course));
            }

            return View(resultListItem);
        }

        //
        // GET: /Student/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Student/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Student/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Student/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Student/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Student/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Student/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

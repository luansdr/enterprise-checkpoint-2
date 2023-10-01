using Fiap.Web.Checkpoint2.ToDo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fiap.Web.Checkpoint2.ToDo.Controllers
{
    public class TaskController : Controller
    {
        private static List<TaskItem> taskItems = new List<TaskItem>();
        private static int nextId = 1;

        public IActionResult Index()
        {
            return View(taskItems);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskItem task)
        {
            task.Id = nextId++;
            taskItems.Add(task);
            TempData["msg"] = "Tarefa cadastrada com sucesso!";
            TempData["color"] = "success";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var task = taskItems.Find(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(TaskItem task)
        {
            var existingTask = taskItems.Find(t => t.Id == task.Id);
            if (existingTask == null)
            {
                return NotFound();
            }

            existingTask.Title = task.Title;
            existingTask.Description = task.Description;

            TempData["msg"] = "Tarefa atualizada com sucesso!";
            TempData["color"] = "success";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var p = taskItems.First(p => p.Id == id);
            taskItems.Remove(p);
            TempData["msg"] = "Tarefa removida com sucesso!";
            TempData["color"] = "success";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult MarkAsCompleted(int id)
        {
            var task = taskItems.Find(t => t.Id == id);

            if (task != null)
            {
                task.IsCompleted = !task.IsCompleted;
                TempData["msg"] = "Tarefa atualizada!";
                TempData["color"] = "success";
            }
            else
            {
                TempData["msg"] = "Tarefa não encontrada!";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var task = taskItems.Find(t => t.Id == id);
            if (task != null)
            {
                taskItems.Remove(task);
                TempData["msg"] = "Tarefa excluída com sucesso!";
                TempData["color"] = "success";
            }
            else
            {
                TempData["msg"] = "Tarefa não encontrada!";
                TempData["color"] = "danger";
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Search(int id)
        {
            var task = taskItems.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            return PartialView("Search", task);
        }
    }
    }

using EX4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EX4.Controllers
{
    public class CustomerController : Controller
    {
        //khai báo biến CustomerRepository

        static CustomerRepository listCustomer;

        public CustomerController()

        {

            //khởi tạo CustomerRepository

            listCustomer = new CustomerRepository();

        }
        // GET: /Customer/CustomerDetail (action trả về thông tin chi tiết 1 khách hàng cho view CustomerDetail

        public ActionResult CustomerDetail()
        {
            //tạo một đối tượng Customer ( nhớ using Lab04.Models vào nhé)
            Customer cus = new Customer()
            {
                CustomerId = "KH001",

                FullName = "Trịnh Văn Chung",

                Address = "Hà Nội",

                Email = "devmaster.founder@gmail.com",

                Phone = "0978.611.889",

                Balance = 15200000
            };
            //cách 1 gán dữ liệu vào ViewBag để chuyển tới View

            //ViewBag.customer = cus;

            //return View();

            //có thể truyền dữ liệu qua đối tượng model để chuyển tới View

            return View(cus);
        }
        //GET /Product/CustomerList (action trả về danh sách khách hàng cho view CustomerList)

        public ActionResult CustomerList()
        {
            //tạo một danh sách khách hàng
            List<Customer> listcustomer = new List<Customer>(){
            new Customer(){ CustomerId = "KH001",FullName = "Trịnh Văn Chung",Address = "Hà Nội",Email = "devmaster.founder@gmail.com",Phone = "0978.611.889",Balance = 15200000},
            new Customer(){ CustomerId = "KH002", FullName = "Đỗ Thị Cúc",Address = "Hà Nội",Email = "cucdt@gmail.com",Phone = "0986.767.444",Balance = 2200000},
            new Customer(){ CustomerId = "KH003",FullName = "Nguyễn Tuấn Thắng",Address = "Nam Định",Email = "thangnt@gmail.com",Phone = "0924.656.542",Balance = 1200000},
            new Customer(){ CustomerId = "KH004", FullName = "Lê Ngọc Hải",Address = "Hà Nội",Email = "hailn@gmail.com",Phone = "0996.555.267",Balance = 6200000 }
        };
            //gán dữ liệu vào ViewBag để chuyển qua View
            ViewBag.listcustomer = listcustomer;
            return View();
        }

        // GET: /Customer/GetCustomers

        public ActionResult GetCustomers()

        {

            return View(listCustomer.GetCustomers());

        }

        //POST: /Customer/GetCustomers

        [HttpPost]

        public ActionResult GetCustomers(string name)

        {

            var search = listCustomer.SearchCustomer(name).Where(c => c.FullName.Contains(name)).ToList();
            return View(search);

        }

        // GET: /Customer/Details/5

        public ActionResult Details(string id)

        {

            return View(listCustomer.GetCustomer(id));

        }

        // GET: /Customer/Create

        public ActionResult Create()

        {

            return View();

        }

        // POST: /Customer/Create

        [HttpPost]

        public ActionResult Create(Customer cus)

        {

            listCustomer.AddCustomer(cus);
            return RedirectToAction("GetCustomers");

        }

        // GET: /Customer/Edit/5

        public ActionResult Edit(string id)

        {

            return View(listCustomer.GetCustomer(id));

        }

        // POST: /Customer/Edit

        [HttpPost]

        public ActionResult Edit(Customer cus)

        {

            listCustomer.UpdateCustomer(cus);

            return RedirectToAction("GetCustomers");

        }

        // GET: /Customer/Delete/5

        public ActionResult Delete(string id)

        {

            listCustomer.DeleteCustomer(listCustomer.GetCustomer(id));

            return RedirectToAction("GetCustomers");

        }
    }
}
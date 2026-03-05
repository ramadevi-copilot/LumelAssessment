using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace Project1
{
    public class ResponseData
    {
        public int Status = 0;
        public string Message = "";
        public int waitlist_position;
        public string reservation_id;
    }
    public class InventoryManagement
    {
        public int TotalInventory;
        [System.Web.Http.Authorize(Roles = "Admin")]
        [HttpPost]
        public IHttpActionResult SetInventoryList(int InventoryLimit)
        {
            TotalInventory = InventoryLimit;
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult CheckReservationStatus(string reservation_id, string expires_at)
        {
            if(TotalInventory>0)
            {
                TotalInventory--;
            }
            ResponseData responseData = new ResponseData();
            if (TotalInventory<InventoryLimit)
            {
                responseData.Status = 0;
                responseData.reservation_id = reservation_id;
                return (responseData);
            }
            else
            {
                responseData.Status = 0;
                responseData.Message = "Successfully Booked";
                return (responseData);

            }
           
        }



    }
}

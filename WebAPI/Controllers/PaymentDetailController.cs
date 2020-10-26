using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")] // set the route for this particular method [controller] will be replaced by the controller name
    [ApiController]
    public class PaymentDetailController : ControllerBase // new API controller inherits from ControllerBase - scaffolding includes all CRUD functions
    {
        private readonly PaymentDetailContext _context; 

        //Through dependency injection whenever we create a controller with a constructor parameter of the type PaymentDetailContext the IServiceCollection property services will provide a new instance of PaymentDetailController into this constructor parameter "context" - no need to explicitly create instance of DbContext class
        public PaymentDetailController(PaymentDetailContext context)  
        {
            _context = context;
        }

        // GET: api/PaymentDetail
        // this returns the entire collection of Payment Details that have been saved inside the table
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDetail>>> GetPaymentDetails()
        {
            return await _context.PaymentDetails.ToListAsync(); 
        }

        // GET: api/PaymentDetail/5
        // this GET passes the id as parameter, it will get the single object that corresponds to the id
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDetail>> GetPaymentDetail(int id)
        {
            var paymentDetail = await _context.PaymentDetails.FindAsync(id);

            if (paymentDetail == null)
            {
                return NotFound();
            }

            return paymentDetail;
        }

        // PUT: api/PaymentDetail/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        // this takes as parameters the id and the PaymentDetail object to be updated
        public async Task<IActionResult> PutPaymentDetail(int id, PaymentDetail paymentDetail)
        {
            if (id != paymentDetail.PMId)
            {
                return BadRequest();
            }

            _context.Entry(paymentDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PaymentDetail
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        // this takes a new PaymentDetail object as a parameter and creates a new database object from it
        [HttpPost]
        public async Task<ActionResult<PaymentDetail>> PostPaymentDetail(PaymentDetail paymentDetail) //onSubmit in the Angular project submits its value into this function
        {
            // new payment detail object is added to the database, all the tables are changed
            _context.PaymentDetails.Add(paymentDetail);
            await _context.SaveChangesAsync();

            // a new database record is created with the values of the new instance
            return CreatedAtAction("GetPaymentDetail", new { id = paymentDetail.PMId }, paymentDetail);
        }

        // DELETE: api/PaymentDetail/5
        [HttpDelete("{id}")]
        // deletes a PaymentDetail from the database according to its id
        public async Task<ActionResult<PaymentDetail>> DeletePaymentDetail(int id)
        {
            var paymentDetail = await _context.PaymentDetails.FindAsync(id);
            if (paymentDetail == null)
            {
                return NotFound();
            }

            _context.PaymentDetails.Remove(paymentDetail);
            await _context.SaveChangesAsync();

            return paymentDetail;
        }

        private bool PaymentDetailExists(int id)
        {
            return _context.PaymentDetails.Any(e => e.PMId == id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using CreditCardProject.Models;
using CreditCardProject.MockData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CreditCardProject.Controllers
{
    [ApiController]
    [Route("api/banks")]
    public class BankController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBanks()
        {
            try
            {
                // Get the list of banks from BanksData
                List<Banks> banks = BanksData.Banks;
                return Ok(banks); // Return the list of banks as JSON
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("search")]
        public IActionResult SearchBanks(string bankName)
        {
            try
            {
                if (string.IsNullOrEmpty(bankName))
                {
                    // If no bankName provided, return bad request
                    return BadRequest("Bank name is required for searching.");
                }

                // Filter banks based on the provided bank name (case-insensitive)
                var filteredBanks = BanksData.Banks.Where(b => b.Name.ToLower().Contains(bankName.ToLower())).ToList();
                return Ok(filteredBanks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("names")]
        public IActionResult GetBankNames()
        {
            try
            {
                var bankNames = BanksData.Banks.Select(b => b.Name).ToList();
                return Ok(bankNames);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}

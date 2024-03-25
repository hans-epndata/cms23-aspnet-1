﻿using Infrastructure.Contexts;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Attributes;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [UseApiKey]
    public class SubscribersController(ApiContext context) : ControllerBase
    {
        private readonly ApiContext _context = context;

        [HttpGet]
        public async Task<IActionResult> GetSubscribers()
        {
            return Ok(await _context.Subscribers.ToListAsync());
        }



        [HttpPost]
        public async Task<IActionResult> Subscribe(SubscribeForm form)
        {
            if (ModelState.IsValid)
            {
                if (!await _context.Subscribers.AnyAsync(x => x.Email == form.Email))
                {
                    try
                    {
                        _context.Subscribers.Add(SubscribeFactory.Create(form));
                        await _context.SaveChangesAsync();
                        return Created("", null);
                    }
                    catch { }
                    return Problem();
                }

                return Conflict();
            }

            return BadRequest();
        }


        [HttpDelete]
        public async Task<IActionResult> UnSubscribe(string email)
        {
            if (ModelState.IsValid)
            {
                var subscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.Email == email);
                if (subscriber != null)
                {
                    _context.Subscribers.Remove(subscriber);
                    await _context.SaveChangesAsync();
                    return Ok();
                }

                return NotFound();
            }

            return BadRequest();
        }
    }
}

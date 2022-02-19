﻿using CleanMOQasine.Business.Exceptions;
using System.Net;
using System.Text.Json;

namespace CleanMOQasine.API.Infrastructures
{
    public class GlobalExeptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExeptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (TypeMismatchException error)
            {
                ConstructResponse(context, HttpStatusCode.BadRequest, error.Message);
            }
            catch (AuthenticationException error)
            {
                ConstructResponse(context, (HttpStatusCode)401, error.Message);
            }
            catch (Exception error)
            {
                await ConstructResponse(context, HttpStatusCode.BadRequest, error.Message);
            }
        }

        private async Task ConstructResponse(HttpContext context, HttpStatusCode code, string message)
        {
            context.Response.ContentType = "applications/json";
            context.Response.StatusCode = (int)code;
            var result = JsonSerializer.Serialize(new { message = message });
            await context.Response.WriteAsync(result);
        }
    }
}

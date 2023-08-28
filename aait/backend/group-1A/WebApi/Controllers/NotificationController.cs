using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO.NotificationDTO;
using Application.Features.NotificationFeaure.Requests.Commands;
using Application.Features.NotificationFeaure.Requests.Queries;
using Application.Response;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("notification/")]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public NotificationController(IMediator mediator)
        {
            _mediator = mediator;
        }   

        [HttpGet("all")]
        public async Task<ActionResult<BaseResponse<List<NotificationResponseDTO>>>> GetALL(){
            var userId = 3;
            var result = await _mediator.Send(new GetAllNotificationsQuery { UserId = userId});
            return Ok(result);
        }

        [HttpGet("unread")]
        public async Task<ActionResult<List<BaseResponse<NotificationResponseDTO>>>> GetALLUnread(){
            var userId = 3;
            var result = await _mediator.Send(new GetUnreadNotification { UserId = userId});
            return Ok(result);
        }

        [HttpGet("/{id}")]
        public async Task<ActionResult<BaseResponse<List<NotificationResponseDTO>>>> Get(int id){
            var result = await _mediator.Send(new GetSingleNotification { NotificationId = id});
            return Ok(result);
        }

        [HttpPost("mark-all-read")]
        public async Task<ActionResult<BaseResponse<List<NotificationResponseDTO>>>> MarkAllRead(){
            var userId = 3;
            var result = await _mediator.Send(new MarkReadAllRequest {UserId = userId});
            return Ok(result);
        }

        [HttpPost("mark-read/{id}")]
        public async Task<ActionResult<BaseResponse<List<NotificationResponseDTO>>>> MarkRead(int id){
            var userId = 3;
            var result = await _mediator.Send(new MarkAsReadCommand {UserId = userId, NotificationId = id});
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<BaseResponse<List<NotificationResponseDTO>>>> Delete(int id){
            var userId = 3;
            var result = await _mediator.Send(new DeleteNotification { UserId = userId, NotificationId = id});
            return Ok(result);
        }

    }
}
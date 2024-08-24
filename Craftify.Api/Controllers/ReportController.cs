using Craftify.Application.Report.Queries.GetActiveSubscriptions;
using Craftify.Application.Report.Queries.GetActiveUsers;
using Craftify.Application.Report.Queries.GetApprovedWorkers;
using Craftify.Application.Report.Queries.GetAverageWorkerHourlyRate;
using Craftify.Application.Report.Queries.GetBlockedUsers;
using Craftify.Application.Report.Queries.GetBookingsByStatus;
using Craftify.Application.Report.Queries.GetNewUsersThisMonth;
using Craftify.Application.Report.Queries.GetTotalBookings;
using Craftify.Application.Report.Queries.GetTotalRevenueByActiveSubscriptions;
using Craftify.Application.Report.Queries.GetTotalRevenueBySubscriptions;
using Craftify.Application.Report.Queries.GetTotalRevenueFromBookings;
using Craftify.Application.Report.Queries.GetTotalServiceCategories;
using Craftify.Application.Report.Queries.GetTotalSubscriptions;
using Craftify.Application.Report.Queries.GetTotalUsers;
using Craftify.Application.Report.Queries.GetTotalWorkers;
using Craftify.Application.Report.Queries.GetUnapprovedWorkers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Craftify.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ApiController
    {
        private readonly IMediator _mediator;

        public ReportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("active-subscriptions")]
        public async Task<IActionResult> GetActiveSubscriptions()
        {
            var result = await _mediator.Send(new GetActiveSubscriptionsQuery());
            return Ok(result);
        }

        [HttpGet("active-users")]
        public async Task<IActionResult> GetActiveUsers()
        {
            var result = await _mediator.Send(new GetActiveUsersQuery());
            return Ok(result);
        }

        [HttpGet("approved-workers")]
        public async Task<IActionResult> GetApprovedWorkers()
        {
            var result = await _mediator.Send(new GetApprovedWorkersQuery());
            return Ok(result);
        }

        [HttpGet("average-worker-hourly-rate")]
        public async Task<IActionResult> GetAverageWorkerHourlyRate()
        {
            var result = await _mediator.Send(new GetAverageWorkerHourlyRateQuery());
            return Ok(result);
        }

        [HttpGet("blocked-users")]
        public async Task<IActionResult> GetBlockedUsers()
        {
            var result = await _mediator.Send(new GetBlockedUsersQuery());
            return Ok(result);
        }

        [HttpGet("bookings-by-status")]
        public async Task<IActionResult> GetBookingsByStatus()
        {
            var result = await _mediator.Send(new GetBookingsByStatusQuery());
            return Ok(result);
        }

        [HttpGet("new-users-this-month")]
        public async Task<IActionResult> GetNewUsersThisMonth()
        {
            var result = await _mediator.Send(new GetNewUsersThisMonthQuery());
            return Ok(result);
        }

        [HttpGet("total-bookings")]
        public async Task<IActionResult> GetTotalBookings()
        {
            var result = await _mediator.Send(new GetTotalBookingsQuery());
            return Ok(result);
        }

        [HttpGet("total-revenue-by-active-subscriptions")]
        public async Task<IActionResult> GetTotalRevenueByActiveSubscriptions()
        {
            var result = await _mediator.Send(new GetTotalRevenueByActiveSubscriptionsQuery());
            return Ok(result);
        }

        [HttpGet("total-revenue-by-subscriptions")]
        public async Task<IActionResult> GetTotalRevenueBySubscriptions()
        {
            var result = await _mediator.Send(new GetTotalRevenueBySubscriptionsQuery());
            return Ok(result);
        }

        [HttpGet("total-revenue-from-bookings")]
        public async Task<IActionResult> GetTotalRevenueFromBookings()
        {
            var result = await _mediator.Send(new GetTotalRevenueFromBookingsQuery());
            return Ok(result);
        }

        [HttpGet("total-service-categories")]
        public async Task<IActionResult> GetTotalServiceCategories()
        {
            var result = await _mediator.Send(new GetTotalServiceCategoriesQuery());
            return Ok(result);
        }

        [HttpGet("total-subscriptions")]
        public async Task<IActionResult> GetTotalSubscriptions()
        {
            var result = await _mediator.Send(new GetTotalSubscriptionsQuery());
            return Ok(result);
        }

        [HttpGet("total-users")]
        public async Task<IActionResult> GetTotalUsers()
        {
            var result = await _mediator.Send(new GetTotalUsersQuery());
            return Ok(result);
        }

        [HttpGet("total-workers")]
        public async Task<IActionResult> GetTotalWorkers()
        {
            var result = await _mediator.Send(new GetTotalWorkersQuery());
            return Ok(result);
        }

        [HttpGet("unapproved-workers")]
        public async Task<IActionResult> GetUnapprovedWorkers()
        {
            var result = await _mediator.Send(new GetUnapprovedWorkersQuery());
            return Ok(result);
        }
    }
}

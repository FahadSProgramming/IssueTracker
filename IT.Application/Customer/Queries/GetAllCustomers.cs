using AutoMapper;
using IT.Application.Exceptions;
using IT.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IT.Application.Customer.Queries {
    public class GetAllCustomers : IRequest<List<CustomerDto>> {
        public bool? Active { get; set; }
    }

    public class GetAllCustomersHandler : IRequestHandler<GetAllCustomers, List<CustomerDto>> {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public GetAllCustomersHandler(DataContext context, IMapper mapper) {
            _mapper = mapper;
            _context = context;
        }
        public async Task<List<CustomerDto>> Handle (GetAllCustomers request, CancellationToken cancellationToken) {
            List<CustomerDto> response = new List<CustomerDto>();
            List<Domain.Customer> customers;
            if(request.Active.HasValue) {
                customers = await _context.Customers
                                  .Where(x => x.IsActive == request.Active.Value)
                                  .Include(c => c.Country)
                                  ?.ToListAsync();
                
            } else {
                customers = await _context.Customers
                                  .Include(c => c.Country)
                                  .ToListAsync();
            }

            if(customers == null || (customers?.Count ?? 0) <= 0) {
                    throw new NotFoundException("No customers found matching the criteria.");
                }
            response = _mapper.Map<List<CustomerDto>>(customers);
            return response;
        }
    }
}
using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation.Order;
using Core.Aspects.Autofac.Validation;
using Core.Exceptions.General;
using Core.Exceptions.Reservation;
using Core.ResponseModels;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Order;
using Microsoft.EntityFrameworkCore;
using Service.Concrete;

namespace Business.Concrete
{
    public class OrderManager : Manager<Order>, IOrderService
    {
        readonly IOrderDal _orderDal;
        readonly IBranchService _branchService;
        readonly IReservationService _reservationService;
        readonly IMapper _mapper;
        readonly IProductService _productService;
        readonly IUnitOfWork _unitOfWork;

        public OrderManager
            (IOrderDal orderDal,
            IBranchService branchService,
            IReservationService reservationService,
            IMapper mapper,
            IProductService productService,
            IUnitOfWork unitOfWork)
            : base(orderDal)
        {
            _orderDal = orderDal;
            _branchService = branchService;
            _reservationService = reservationService;
            _mapper = mapper;
            _productService = productService;
            _unitOfWork = unitOfWork;
        }



        [SecuredOperation("employee", Priority = 1)]
        [ValidationAspect(typeof(OrderInsertDtoValidator), Priority = 2)]
        public async Task<CreateSuccessResponse> Add(OrderInsertDto orderInsertDto)
        {
            Branch? branch = await _branchService
                .Where(b => b.Id == orderInsertDto.BranchId && !b.IsDeleted)
                .AsNoTracking()
                .Include(b => b.Tables)
                .SingleOrDefaultAsync();


            if (branch == null)
                throw new EntityNotFoundException("Şube");


            if (!branch.Tables.Any(o => o.Id == orderInsertDto.TableId && !o.IsDeleted)) 
                throw new EntityNotFoundException("Masa");


            if (orderInsertDto.ReservationId != null)
            {
                Reservation? reservation = await _reservationService
                    .Where(r =>
                    r.Id == orderInsertDto.ReservationId
                    && r.BranchId == orderInsertDto.BranchId
                    && r.TableId == orderInsertDto.TableId
                    && !r.IsDeleted)
                    .AsNoTracking()
                    .Include(r => r.Order)
                    .SingleOrDefaultAsync();
                
                if (reservation == null)
                    throw new EntityNotFoundException("Rezervasyon");

                if (reservation.Order != null)
                    throw new ReservationAlreadyOrderedException();
            }


            List<int> productIds = orderInsertDto.Products
                .Select(p => p.ProductId)
                .ToList();


            List<Product> products = await _productService
                .Where(p => productIds.Contains(p.Id) && !p.IsDeleted && p.IsActive)
                .ToListAsync();


            List<int> missingProductIds = productIds
                .Except(products.Select(p => p.Id).ToList())
                .ToList();


            if (missingProductIds.Any())
                throw new EntitiesNotFoundException("ürünler")
                {
                    Ids = missingProductIds
                };


            Order order = _mapper.Map<Order>(orderInsertDto);

            products.ForEach(p =>
            {
                int quantity = orderInsertDto.Products.Where(op => op.ProductId == p.Id).Single().Quantity;

                order.OrderProducts.Add(new OrderProduct
                { 
                    ProductId = p.Id,
                    Quantity = quantity,
                    UnitPrice = p.Price
                });
                
                order.TotalPrice += p.Price * quantity;
            });


            await _orderDal.AddAsync(order);
            await _unitOfWork.SaveChangesAsync();

            return new CreateSuccessResponse(CommonMessages.EntityAdded);
        }


    }
}
